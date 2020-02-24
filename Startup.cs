using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoanEvaluator.Startup))]
namespace LoanEvaluator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
