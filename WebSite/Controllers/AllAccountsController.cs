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

        public void SetModel()
        {
            string name = (string)RouteData.Values["id"];
            PolisaBL polisaBL = new PolisaBL();
            DAL.Client client = new DAL.Client();

            client.TeudatZehut = "24416422".PadLeft(12, '0');

            if (SessionVar.Current.AccountData == null)
            {
                model = SessionVar.Current.AccountData = polisaBL.GetPolisas(client);

                SessionVar.Current.AccountData = model;
            }
            else
                model = SessionVar.Current.AccountData;

            if (SessionVar.Current.Lut == null)
            {
                SessionVar.Current.Lut = new LUT();
            }
            lut = SessionVar.Current.Lut;
            ViewBag.LUT = SessionVar.Current.Lut;
        }


        public ActionResult Index()
        {
            SetModel();
            if (model == null)
                return RedirectToAction("NotFound");

            return View(model);
        }

        private struct AccountsRecStruct
        {
            public string AccountName;
            public string AccountNumber;
        }

        public JsonResult GetAllAccountsFilter ()
        {

            SetModel();

            List<AccountsRecStruct> accounts = new List<AccountsRecStruct>();
            AccountsRecStruct accountRec;

            string line;
            for (int i=0; i < model.Count(); i++)
            {
                line = lut.Get("SUG-MUTZAR-PENSIONI", model[i].Customer.SUG_MUTZAR_PENSIONI) + "-" + 
                       model[i].Customer.Yatzran.SHEM_YATZRAN_SHORT + " " +
                       model[i].MISPAR_POLISA_O_HESHBON;

                accountRec.AccountName = line;
                accountRec.AccountNumber = model[i].MISPAR_POLISA_O_HESHBON;
                accounts.Add(accountRec);
            }
            
            var accountsJSON = 
                    (from account in accounts
                       select new
                       {
                           account.AccountName,
                           account.AccountNumber
                       });

            return (Json(accountsJSON, JsonRequestBehavior.AllowGet));

        }


    }

}
