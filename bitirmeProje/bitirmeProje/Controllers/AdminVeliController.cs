using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using bitirmeProje.Models;

namespace bitirmeProje.Controllers
{
    public class AdminVeliController : Controller
    {
        servisOtomasyonDB db = new servisOtomasyonDB();
        // GET: AdminVeli
        public ActionResult Index()
        {
            return View(db.Veliler.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "veliID,adSoyad,iletisimTel,mail")] Veliler veli)
        {
            if (ModelState.IsValid)
            {
                db.Veliler.Add(veli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veli);
        }

        // GET: AdminVeli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veliler veli = db.Veliler.Find(id);
            if (veli == null)
            {
                return HttpNotFound();
            }
            return View(veli);
        }

        // POST: AdminVeli/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "veliID,adSoyad,iletisimTel,mail")] Veliler veli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veli);
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
