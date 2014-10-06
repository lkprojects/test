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
        private List<DAL.HeshbonOPolisa> model;
        private LUT lut;
        public ActionResult Index()
        {
            string name = (string)RouteData.Values["id"];
            PolisaBL polisaBL = new PolisaBL();
            DAL.Client client = new DAL.Client();

            client.TeudatZehut = "24416422".PadLeft(12, '0');

            if (SessionVar.Current.AccountData == null)
            {
                model = SessionVar.Current.AccountData = polisaBL.GetPolisas(client);

                if (model == null)
                    return RedirectToAction("NotFound");

                SessionVar.Current.AccountData = model;
            }
            else
                model = SessionVar.Current.AccountData;


            if (SessionVar.Current.Lut == null)
            {
                SessionVar.Current.Lut = new LUT();
            }
            ViewBag.LUT = SessionVar.Current.Lut;

            return View(model);
        }

    }
}
