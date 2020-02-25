using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Loan.Data;
using Loan.Data.Models;
using Loan.Data.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Provider;
using Paystack.Net.SDK.Transactions;

namespace LoanEvaluator.Controllers
{
    public class SubscribedController : Controller
    {
        private static string ReturnUrl;
        private readonly ISubscribed _subscribed;
        private readonly Subscribed _subscriber;
        private readonly ILogger _logger;
        private static decimal amount;
        private static string Reference;

        public SubscribedController(ISubscribed _subscribed, Subscribed subscriber, ILogger logger)
        {
            this._subscribed = _subscribed;
            _subscriber = subscriber;
            _logger = logger;
        }

        // GET: Subscribed
        public ActionResult Subscribe(int id, string returnurl)
        {
            
            ReturnUrl = returnurl;
            Session["providerId"] = id;
            var model = new SubscriptionModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Subscribe(decimal amount)
        {
            var id = (int) Session["providerId"];
            // var callbackurl = Request.Url.ToString();
            var callbackurl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            var price = (int) amount * 100;
            var useremail = User.Identity.GetUserName();
            var connectionInstance = new PaystackTransaction(ConfigurationManager.AppSettings["Credential"]);
            var response = await connectionInstance.InitializeTransaction(useremail, price, callbackUrl: callbackurl);

            try
            {

          
            if (response.status)
            {
                Reference = response.data.reference;
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Redirect(response.data.authorization_url); //Redirects your browser to the secure URL
                _logger.WriteInformation(response.message);
            }

            string reference = Reference;

            string secretKey = ConfigurationManager.AppSettings["Credential"];
            var paystackTransactionApi = new PaystackTransaction(secretKey);
            var response1 = await paystackTransactionApi.VerifyTransaction(reference);

            if (response1.status && response1.data.status.Equals("success"))
            {
                var userid = User.Identity.GetUserId();
                var username = User.Identity.GetUserName();
                var sub = BusinessLogic.ActivateSubscribed(amount, "success", userid, username);
                _subscribed.Add(sub);

                if (_subscribed.comit())
                {
                    TempData["subscribe"] =
                        $"subscription successful {sub.SubscribedMonth} months, amount {sub.AmountSubscribed} ,expiries{sub.SubscribtionExpiryDate}";
                    return RedirectToAction("SiteDetails", "Loan", new {id = id});
//          return RedirectToAction("MyNextAction",
//            new { r = Request.Url.ToString() });
//          return Redirect(ReturnUrl);
                }
            }
            }
            catch (Exception e)
            {
                _logger.WriteError(e.ToString());
                throw;
            }

            return RedirectToAction("Failed", "Subscribed");
        }

        public ActionResult Failed()
        {
            return View();
        }

        public ActionResult MyNextAction()
        {
            // get the current urls
            var callbackurl = Request.Url.ToString();
            return Redirect(Request.QueryString["r"]);
        }
    }
}