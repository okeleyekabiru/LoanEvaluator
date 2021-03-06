﻿using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Loan.Data;
using Loan.Data.Services;

namespace LoanEvaluator.App_Start
{
    public class ContainerConfig
    {

        public static void RegisterContainer(HttpConfiguration httpconfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers((typeof(MvcApplication).Assembly));
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MemoryStorage>()
                .As<ILoan>()
                .SingleInstance();
            builder.RegisterType<Subscribed>().InstancePerRequest();
            builder.RegisterType<SqlliteDbContext>()
                .As<IMapLoan>().InstancePerRequest();
            builder.RegisterType<SubscribeMemory>().As<ISubscribed>().InstancePerRequest();
            builder.RegisterType<LoanProviderMemory>().As<ILoanProvides>().InstancePerRequest();
            builder.RegisterType<Clicktrack>().As<ITracker>().InstancePerRequest();
            builder.RegisterType<LoanDbContext>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpconfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}