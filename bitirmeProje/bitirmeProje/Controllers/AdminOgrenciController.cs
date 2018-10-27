using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bitirmeProje.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace bitirmeProje.Controllers
{
    public class AdminOgrenciController : Controller
    {
        servisOtomasyonDB db = new servisOtomasyonDB();

        //adrese silme veliye silme ekle ogrencinden servis değişikliğine izin ver
        // GET: AdminOgrenci
        public ActionResult Index()
        {
            var ogrenci = db.Ogrenci.Include(K => K.Servis);
            return View(ogrenci.ToList());
        }

        // GET: AdminOgrenci/Create
        public ActionResult Create()
        {
            ViewBag.veliID = new SelectList(db.Veliler, "veliID","adSoyad");
            ViewBag.adresID = new SelectList(db.Adres, "adresID", "koordinat", "adresBilgi");
            ViewBag.servisID = new SelectList(db.Servis, "servisID", "ServisGuzergahIsim", "koordinatID");
            return View();
        }

        // POST: AdminOgrenci/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ogrenciID,adSoyad,adresID,sinif,tcNo,veliID,gelmeDurum,servisID")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Ogrenci.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.veliID = new SelectList(db.Veliler, "veliID","adSoyad",ogrenci.veliID);
            ViewBag.adresID = new SelectList(db.Adres, "adresID", "koordinat", "adresBilgi",ogrenci.adresID);
            ViewBag.servisID = new SelectList(db.Servis, "servisID", "ServisGuzergahIsim","koordinatID", ogrenci.servisID);
            return View(ogrenci);
        }

        // GET: AdminOgrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.veliID = new SelectList(db.Veliler, "veliID", "adSoyad", ogrenci.veliID);
            ViewBag.adresID = new SelectList(db.Adres, "adresID", "koordinat", "adresBilgi", ogrenci.adresID);
            ViewBag.servisID = new SelectList(db.Servis, "servisID", "ServisGuzergahIsim", "koordinatID", ogrenci.servisID);
            return View(ogrenci);
        }

        // POST: AdminOgrenci/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ogrenciID,adSoyad,adresID,sinif,tcNo,veliID,gelmeDurum,servisID")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.veliID = new SelectList(db.Veliler, "veliID", "adSoyad", ogrenci.veliID);
            ViewBag.adresID = new SelectList(db.Adres, "adresID", "koordinat", "adresBilgi", ogrenci.adresID);
            ViewBag.servisID = new SelectList(db.Servis, "servisID", "ServisGuzergahIsim", "koordinatID", ogrenci.servisID);
            return View(ogrenci);
        }

        // GET: AdminOgrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // POST: AdminOgrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            db.Ogrenci.Remove(ogrenci);
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
