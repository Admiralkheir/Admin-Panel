using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using bitirmeProje.Models;


namespace bitirmeProje.Controllers
{
    public class AdminServisController : Controller
    {
        private servisOtomasyonDB db = new servisOtomasyonDB();


        // GET: AdminServis
        public ActionResult Index()
        {
            var servis = db.Servis.Include(s => s.Koordinat);
            return View(servis.ToList());
        }


        // GET: AdminServis/Create
        public ActionResult Create()
        {
            ViewBag.KoordinatID = new SelectList(db.Koordinat, "koordinatID","konumBilgisi");
            return View();
        }

        // POST: AdminServis/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="servisID,ServisGuzergahIsim,koordinatID")] Servis servis)
        {
                if (ModelState.IsValid)
                {
                    db.Servis.Add(servis);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.KoordinatID = new SelectList(db.Koordinat, "koordinatID", "konumBilgisi", servis.koordinatID);
            return View(servis);
                
            
        }

        // GET: AdminServis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            ViewBag.KoordinatID = new SelectList(db.Koordinat, "koordinatID", "konumBilgisi", servis.koordinatID);
            return View(servis);
        }

        // POST: AdminServis/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "servisID,ServisGuzergahIsim,koordinatID")] Servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KoordinatID = new SelectList(db.Koordinat, "koordinatID", "konumBilgisi", servis.koordinatID);
            return View(servis);
        }

        // GET: AdminServis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Servis.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // POST: AdminServis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servis servis = db.Servis.Find(id);
            db.Servis.Remove(servis);
            db.SaveChanges();
            return RedirectToAction("Index");
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
