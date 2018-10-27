using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using bitirmeProje.Models;
namespace bitirmeProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        servisOtomasyonDB db = new servisOtomasyonDB();


        public ActionResult Index()
        {
            ViewBag.veliSayisi = db.Veliler.Count();
            ViewBag.servisSayisi = db.Servis.Count();
            ViewBag.ogrenciSayisi = db.Ogrenci.Count();
            ViewBag.guzergahSayisi = db.Adres.Count();


            return View();
        }
    }
}
//layout tasarlanmadı(Admin için) burada kaldım