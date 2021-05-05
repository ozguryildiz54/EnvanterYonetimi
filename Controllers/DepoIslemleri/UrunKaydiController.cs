using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class UrunKaydiController : Controller
    {
        envanterTakipWebEntities db = new envanterTakipWebEntities(); // Entity Framework ile veritabanı bağlantısı
        
        // GET: UrunKaydi
        [HttpGet]
        [Route("UrunKaydi")] //Url yönlendirmesi; UrunKaydi sayfası bu yönlendirme ile çalıştırılır.
        public ActionResult Index() // Sayfa yüklendiğinde çalıştırılacak olan blok.
        {
            // Sayfa yüklendiğinde cihaz türlerini veritabanından çekip Select etiketi içine aktarmak için verileri ViewBag içine aktarıyoruz.
            List<CihazTuru> CihazTurleri = db.CihazTuru.ToList();
            ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip"); // CihazTuru tablosunda ki cihazTuruId ve cihazTip niteliklerini seçiyoruz.
            return View();
        }

        [Route("cihazTuruGetir")] //Url yönlendirmesi; cihazTuruGetir methodu bu yönlendirme ile çalıştırılır.
        public JsonResult cihazTuruGetir(int cihazTuruId) // Seçili cihaz türünün id değerine göre cihaz modelini listeleyip Json olarak döndürür.
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Modeller> Modeller = db.Modeller.Where(x => x.cihazTuruId == cihazTuruId).ToList();
            return Json(Modeller, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("UrunKaydi")] //Url yönlendirmesi; UrunKaydi sayfasının sunucuya veri göndereceği method.
        public ActionResult Index(Depo kayit) // Depo tablosunun tipinde bir referans nesnesi parametre olarak tetiklenir.
        {
            Boolean mesaj; 
            try
            {
                if (ModelState.IsValid) // Model içerisinde tanımlanan doğrulama sınıfında ki kontrolleri sağlar. 
                {
                    kayit.islemZaman = DateTime.Now.ToString(); // İşlem zamanı için şuan ki zamanı nesnemize atıyoruz.
                    kayit.islemiYapan = User.Identity.Name; // İşlemi yapan kişi bilgisi için çerezlerden kullanıcı adını nesnemize atıyoruz.
                    kayit.kullanim = "aktif"; // Her yeni kayıt değerimiz silme işlemi olmadığından aktif değeri ile saklanır.

                    db.Depo.Add(kayit); // kayit nesnemiz Depo tablosuna yeni bir kayıt olarak eklenir. Tam olarak insert sorgusu ile aynı işi yapar.
                    db.SaveChanges();
                    mesaj = true; // Kayıt başarılı!
                    ViewBag.Message = mesaj;
                }
            }
            catch // Kayıt başarısız!
            {
                mesaj = false;
                ViewBag.Message = mesaj;
            }

            return View();
        }
    }
}