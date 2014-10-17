using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebSite.Models.Business;

namespace WebSite.Controllers
{
    public class DepositsController : Controller
    {
        private PolisaBL polisaBL = new PolisaBL();

        // GET: HafkadotMetchilatShanas
        public ActionResult Index()
        {
            string id = (string)RouteData.Values["id"];
            if (id == null || id == "")
                id = "24416422";

            return View(polisaBL.GetDeposits(id));
        }

    }
}
