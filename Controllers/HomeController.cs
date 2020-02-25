
using System.Web.Mvc;

namespace LoanEvaluator.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Post()
        {
            return View();
        }

        public ActionResult Element()
        {
            return View();
        }

        public ActionResult SinglePost()
        {
            return View();
        }
    }
}