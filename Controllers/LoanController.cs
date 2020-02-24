using Loan.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loan.Data.Models;
using System.Web.Routing;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using LoanEvaluator;
using Microsoft.AspNet.Identity;

namespace LoanComparerApp.Controllers
{
  public class LoanController : Controller
  {
    ILoan db;
    IMapLoan maps;
    private readonly ILoanProvides _pd;
    private readonly ITracker _tracker;
    private readonly ISubscribed _subscribed;

    public LoanController(ILoan db, IMapLoan map, ILoanProvides pd, ITracker tracker,ISubscribed subscribed)
    {
      this.db = db;
      this.maps = map;
      _pd = pd;
      _tracker = tracker;
      _subscribed = subscribed;
    }

    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult AllLoan()
    {
      var model = db.GetAll();
      if (model == null)
      {
        return RedirectToAction("NotFound");
      }

      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(Loans loan)
    {
      db.Clear();
      db.Add(loan);
      return RedirectToAction("CheckSite");
    }

    public ActionResult NotFound()
    {
      return View();
    }

    public ActionResult CheckSite()
    {
      var model = maps.GetAll(db.GetLoans().amountToBeBorrrowed);

      if (model == null)
      {
        return RedirectToAction("NotFound");
      }

      if (model.ToList().Count == 0)
      {
        return RedirectToAction("NotFound");
      }

      return View(model);
    }

    [Authorize]
    public ActionResult SiteDetails(int Id)
    {
      if (!ModelState.IsValid)
      {
        return RedirectToAction("NotFound");
      }
      
      var model = maps.Get(Id);
      ViewBag.id = Id;
      db.CalculateInterest(model.Rate);
      var models = db.Get();

      if (models == null)
      {
        return RedirectToAction("NotFound");
      }

      models.WebsiteName = model.Loansite;
      models.Rate = model.Rate;
      models.Calculatedloan = db.CalculateInterest(model.Rate);

      return View(models);
    }

    public ActionResult Redirect(int Id)
    {
      var model = maps.Get(Id);
      var userId = User.Identity.GetUserId();
      if (model == null)
      {
        return RedirectToAction("NotFound");
      }

      var website = model.websitelink;
      if (_subscribed.GetSubscribedByUserId(userId).Count > 0)
      {
        _tracker.AddToTracker(model.Loansite, userId);
        var checkIfUserIsAvailable = _tracker.GetvaluebyproviderNameAndUserid(model.Loansite, userId);
        if (checkIfUserIsAvailable)
        {
          var providertoupdate1 = _pd.GEtLoanProvidersbyName(model.Loansite);
          providertoupdate1.CountVisit += 1;
          if (_pd.Commit())
          {
            return Redirect(website);
          }

        }

        var providertoupdate = _pd.GEtLoanProvidersbyName(model.Loansite);
        providertoupdate.UniqueCountVisit += 1;
        providertoupdate.CountVisit += 1;
        _pd.UpdateLoanProvides(providertoupdate);
        _pd.Commit();
        return Redirect(website);
      }

      var returnUrl = Request.Url.ToString();
      var routeValues = new RouteValueDictionary
      {
        {"id", Id},
        {"returnUrl", returnUrl}
      };

      return RedirectToAction("Subscribe", "Subscribed", routeValues
    );
  }

    [HttpGet]
    public ActionResult CreateLoan()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateLoan(MapLoans loan)
    {
      if (loan == null)
      {
        return RedirectToAction("NotFound");
      }

      TempData["message"] = "you have successfully  created another loan ";
      maps.Add(loan);
      return RedirectToAction("AllMapLoan");
    }

    public ActionResult ALlMapLoan()
    {
      var model = maps.GetAlls();
      return View(model);
    }

    public ActionResult Loanprovider()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Loanprovider(LoanProviders providers)
    {
      _pd.AddLoanProvides(providers);
      _pd.Commit();
      return View();
    }
  }
}