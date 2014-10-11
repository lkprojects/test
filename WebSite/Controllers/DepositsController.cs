using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebSite.Controllers
{
    public class DepositsController : Controller
    {
        private Entities db = new Entities();

        // GET: HafkadotMetchilatShanas
        public ActionResult Index()
        {
            var hafkadotMetchilatShanas = db.HafkadotMetchilatShanas.Include(h => h.PirteiTaktziv);
            return View(hafkadotMetchilatShanas.ToList());
        }

        // GET: HafkadotMetchilatShanas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HafkadotMetchilatShana hafkadotMetchilatShana = db.HafkadotMetchilatShanas.Find(id);
            if (hafkadotMetchilatShana == null)
            {
                return HttpNotFound();
            }
            return View(hafkadotMetchilatShana);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
