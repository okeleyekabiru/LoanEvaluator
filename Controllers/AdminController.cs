using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loan.Data.Models;
using Loan.Data.Services;
using Microsoft.Owin.Logging;
using NLog;

namespace LoanEvaluator.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILoanProvides _db;
        Logger _logger = LogManager.GetCurrentClassLogger();

        // GET: Admin
        public AdminController(ILoanProvides _db)
        {
            this._db = _db;
        }

        public ActionResult AllView()
        {
            IEnumerable<LoanProviders> model;
            try
            {
                model = _db.GetAllLoanProvider();
                return View(model);
            }
            catch (Exception e)
            {
                _logger.Error(e);

                return RedirectToAction("NotFound", "Loan");
            }
        }
    }
}