using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Business;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AllAccountsController : Controller
    {
        //
        // GET: /AllAccounts/

        public ActionResult Index()
        {
            var name = (string)RouteData.Values["id"];
            var polisaBL = new PolisaBL();
            DAL.Client client = new DAL.Client();
            client.TeudatZehut = "24416422".PadLeft(12, '0');
            var model = polisaBL.GetPolisas(client);

            if (model == null)
                return RedirectToAction("NotFound");

            LUT lut = new LUT();
            ViewBag.LUT = lut;
            string x = lut.Get("Client", "Status", 0);
            return View(model);
        }

    }
}
