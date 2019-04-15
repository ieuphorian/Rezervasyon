using Rezervasyon.Web.Data;
using Rezervasyon.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezervasyon.Web.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db;
        public HomeController()
        {
            db = new AppDbContext();
        }
        public ActionResult Index()
        {
            return View("KayitOl");
        }
        
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RandevuAlModel model)
        {
            if (ModelState.IsValid)
            {
                if (!TCKimlikKontrolEt(model.Ad, model.Soyad, model.DogumTarihi, model.TCNo))
                {
                    TempData["Error"] = "TC Kimlik bilgileriniz ile ad soyad, doğum yılınız eşleşmiyor.";
                    return View(model);
                }
                db.Kayitlar.Add(new Kayitlar
                {
                    AdSoyad = model.Ad + " " + model.Soyad,
                    Bolum = model.Bolum,
                    DogumTarihi = model.DogumTarihi,
                    Email = model.Email,
                    Okul = model.Okul,
                    OkulNo = model.OkulNo,
                    TCNo = model.TCNo,
                    Telefon = model.Telefon
                });
                db.SaveChanges();
                return View("KayitBasarili");
            }
            TempData["Error"] = "Lütfen boş alan bırakmayınız.";
            return View("KayitOl", model);
        }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(RandevuGirisModel model)
        {
            if (ModelState.IsValid)
            {
                var kayit = db.Kayitlar.SingleOrDefault(f => f.TCNo == model.TCNo);
                kayit.ToplamGirisSayisi++;
                db.SaveChanges();
                return View("GirisBasarili");
            }
            TempData["Error"] = "Lütfen boş alan bırakmayınız.";
            return View(model);
        }

        [NonAction]
        private bool TCKimlikKontrolEt(string ad, string soyad, int dogumTarihi, string tcNo)
        {
            long tc = long.Parse(tcNo);
            bool durum = false;
            try
            {
                using (KPSPublic.KPSPublicSoapClient servis = new KPSPublic.KPSPublicSoapClient())
                {
                    durum = servis.TCKimlikNoDogrula(tc, ad.ToUpper(), soyad.ToUpper(), dogumTarihi);
                }
            }
            catch (Exception)
            {
                durum = false;
            }
            return durum;
        }
    }
}