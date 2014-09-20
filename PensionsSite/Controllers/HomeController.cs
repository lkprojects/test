using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PensionsSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "אינדקס";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "עלינו";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "צור קשר";

            return View();
        }
    }
}
