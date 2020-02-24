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
using Paystack.Net.SDK.Transactions;

namespace LoanEvaluator.Controllers
{
  public class SubscribedController : Controller
  {
    private readonly ISubscribed _subscribed;
    private readonly Subscribed _subscriber;

    public SubscribedController(ISubscribed _subscribed, Subscribed subscriber)
    {
      this._subscribed = _subscribed;
      _subscriber = subscriber;
    }
    // GET: Subscribed
    public ActionResult Subscribe()
    {
      var model = new SubscriptionModel();
      ViewBag.ReturnUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
      return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> Subscribe(decimal amount, string package, string returnUrl)
    {
      var callbackurl = "https://localhost:44340/Subscribed/VerifyPayment";
      var price = (int) amount * 100;
      var useremail = User.Identity.GetUserName();
      var connectionInstance = new PaystackTransaction(ConfigurationManager.AppSettings["Credential"]);
      var response = await connectionInstance.InitializeTransaction(useremail, price, callbackUrl: callbackurl);
      if (response.status)
      {
        Session["paymentRef"] = response.status;
        Response.AddHeader("Access-Control-Allow-Origin", "*");
        Response.AppendHeader("Access-Control-Allow-Origin", "*");
        Response.Redirect(response.data.authorization_url); //Redirects your browser to the secure URL
        return RedirectToAction("VerifyPayment", "Subscribed", new RouteValueDictionary ({ amount= amount, reference = response.status });
      }
 
      return RedirectToAction("Failed", "Subscribed");
    }

    [Authorize]
    public async Task<ActionResult> VerifyPayment(  decimal amount, string reference)
    {
//      string reference = (string) Session["paymentRef"];
      string secretKey = ConfigurationManager.AppSettings["Credential"];
      var paystackTransactionApi = new PaystackTransaction(secretKey);
      var response = await paystackTransactionApi.VerifyTransaction(reference);

      if (response.status && response.data.status.Equals("success"))
      {
        var userid = User.Identity.GetUserId();
        var username = User.Identity.GetUserName();
       var sub = BusinessLogic.ActivateSubscribed(amount, "success", userid, username);
        _subscribed.Add(sub);
       
        if (_subscribed.comit())
        {
          // remember to get the provider id
        }

        //string userId = User.Identity.GetUserId();
        //var loggedInUser = _repo.GetUserById(userId);
        //loggedInUser.ActiveSub = true;
        //Index
//        var month = Convert.ToInt32(TempData["month"]);
//        var startDate = DateTime.Now;
//        var endDate = DateTime.Now.AddDays(month * 31);
//
//        UserIdentity.userEmail = User.Identity.GetUserName();
//        UserIdentity.ValidityPeriod = endDate - startDate;
        //_repo.Save();
        //int providerId = (int)Session["providerId"];
        // Session["paymentRef"] = null;
        //return RedirectToAction("Details", "Provider", new { id = providerId });
      }

      return RedirectToAction("Failed", "Subscribed");
    }

    public ActionResult Failed()
    {
      return View();
    }
  }
}