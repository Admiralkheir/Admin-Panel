using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bitirmeProje.Models;

namespace bitirmeProje.Controllers
{
    public class HomeController : Controller
    {
        servisOtomasyonDB db = new servisOtomasyonDB();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(KullaniciAdmin kullanici)
        {
            var giris = db.KullaniciAdmin.Where(x => x.kullaniciAdi == kullanici.kullaniciAdi).SingleOrDefault();
            try
            {
                if (giris.sifre == kullanici.sifre && giris.kullaniciAdi == kullanici.kullaniciAdi)
                {
                    Session["kullaniciID"] = giris.kullaniciID;
                    Session["kullaniciAdi"] = giris.kullaniciAdi;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}