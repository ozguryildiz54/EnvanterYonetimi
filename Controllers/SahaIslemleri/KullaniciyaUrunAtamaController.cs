using EnvanterYonetimi.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SahaIslemleri
{
    public class KullaniciyaUrunAtamaController : Controller
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2(); // Veritabanına erişim için referans nesnemiz
        String mesaj=""; // İşlem sonucunda ki mesajı saklayacağız.
        cihazDetay model = new cihazDetay(); // Model için referans nesnesi tanımlaması
        Saha saha = new Saha(); // Saha tablosu için referans nesnesi tanımlaması

        // GET: KullaniciyaUrunAtama
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index()
        {
            model.DepoGetir = db.Depo.Where(k=>k.durum=="DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
            return View(model);
        }

        // POST: KullaniciyaUrunAtama
        [HttpPost]
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index(string searchString) // Cihaz aramayı sağlar
        {
            try
            {
                Depo kayit = db.Depo.Where(k => k.envNo == searchString).FirstOrDefault(); // searchString değeri ile eşleşen Depo tablosundaki kayıtları döndürür.
                if (!(kayit == null)) // Kayıt varsa
                {
                    // Depo kayıtları null değer kontrolü
                    #region depoNullKontrol

                    if (kayit.cihazTuruId== null)
                        kayit.cihazTuruId = "";

                    if (kayit.cihazModeliId == null)
                        kayit.cihazModeliId = "";

                    if (kayit.envNo== null)
                        kayit.envNo = "";

                    if (kayit.seriNo== null)
                        kayit.seriNo = "";

                    if (kayit.garantiBas== null)
                        kayit.garantiBas = "";

                    if (kayit.durum == null)
                        kayit.durum = "";

                    if (kayit.islemZaman == null)
                        kayit.islemZaman = "";

                    if (kayit.islemiYapan == null)
                        kayit.islemiYapan = "";

                    if (kayit.kullanim == null)
                        kayit.kullanim = "";

                    if (kayit.aciklama == null)
                        kayit.aciklama = "";

                    if (kayit.sifirIkinciEl == null)
                        kayit.sifirIkinciEl = "";

                    #endregion //

                    model = new cihazDetay() // Dönen kaydı modele ekliyoruz
                    {                        
                        cihazTuruID = kayit.cihazTuruId.ToString(),
                        cihazModeliId = kayit.cihazModeliId.ToString(),
                        envNo = kayit.envNo.ToString(),
                        seriNo = kayit.seriNo.ToString(),
                        garantiBas = kayit.garantiBas.ToString(),
                        durum = kayit.durum.ToString(),
                        islemZaman = kayit.islemZaman.ToString(),
                        islemiYapan = kayit.islemiYapan.ToString(),
                        kullanim = kayit.kullanim.ToString(),
                        aciklama = kayit.aciklama.ToString(),
                        sifirIkinciEl = kayit.sifirIkinciEl.ToString()                       
                    };

                    model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList();  // Kullanıma uygun olan cihazları listememizi sağlar.

                    if (model.durum != "DEPODA")
                    {
                        mesaj = "deviceNotAvaliable"; // Cihaz kullanılabilir değil!
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                    }
                    else if (model.durum == "DEPODA")
                    {
                        mesaj = "findRecord"; // Kayıt var!
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                    }
                       
                    return View(model);
                }
                mesaj = "noRecord"; // Kayıt yok!
                TempData["mesaj"] = mesaj;
                mesaj = "";

                model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
                return View(model);
            }
            catch (Exception) // Beklenmedik durumlar burada toplanır. Sunucu hatası vs.
            {
                mesaj = "errorServer"; // Sunucu hatası!
                TempData["mesaj"] = mesaj;
                mesaj = "";

                model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
                return View(model);
            }
        }

        // POST: kayit
        [HttpPost]
        [Route("kayit")]
        public ActionResult kayit(FormCollection form) // Form alanlarında ki kullanıcıya atanacak cihaz ve kullanıcı verilerini Saha tablosuna kaydeder. 
        {
            try
            {
                // Form alanlarının doldurulmadığını kontrol eder.
                if (form["kullaniciAdi"] == "" || form["kullaniciSoyadi"] == "" || form["sirketId"] == "" || form["lokasyonId"] == "" || form["envNo"] == "" || form["cihazModeliId"] == "" || form["seriNo"] == "" || form["garantiBas"] == "" || form["durum"] == "" || form["aciklama"] == "" || form["sifir_ikinci_el"] == "" || form["cihazTuruId"] == "")
                {
                    mesaj = "formEmpty"; 
                    TempData["mesaj"] = mesaj; // Form alanlarını doldurun hatası View alanına yönlendirilir.
                    mesaj = "";

                    model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
                    return RedirectToAction("Index", "KullaniciyaUrunAtama"); // KullaniciyaUrunAtama sayfasına yönlendirir.
                }

                if (ModelState.IsValid) // Form alanları doğrulandı ise bu blok çalışır.
                {                    
                    saha.kullaniciAdi = form["kullaniciAdi"].Trim();
                    saha.kullaniciSoyadi = form["kullaniciSoyadi"].Trim();
                    saha.sirketId = form["sirketId"].Trim();
                    saha.lokasyonId = form["lokasyonId"].Trim();
                    saha.envNo = form["envNo"].Trim();
                    saha.cihazModelId = form["cihazModeliId"].Trim();
                    saha.seriNo = form["seriNo"];
                    saha.garantiBas = form["garantiBas"].Trim();
                    saha.durum = form["durum"].Trim();
                    saha.aciklama = form["aciklama"].Trim();
<<<<<<< HEAD
                    saha.sifir_ikinci_el = form["sifir_ikinci_el"];
=======
<<<<<<< HEAD
                    saha.sifir_ikinci_el = form["sifir_ikinci_el"];
=======
                    saha.sifir_ikinci_el = form["sifir_ikinci_el"].Trim();
>>>>>>> 7c227c0713be66b688f9075539e8798a6d090bb9
>>>>>>> 4ca5a5afe9c7ab2e2ea38648c32549d06ba9e221
                    saha.operatorId = User.Identity.Name;
                    saha.islemZaman = DateTime.Now.ToString();
                    saha.kullanim = "aktif";
                    saha.cihazTuruId = form["cihazTuruId"].Trim();
                    saha.iade= form["iade"].Trim();
                    saha.termin = form["termin"].Trim();

                    db.Saha.Add(saha);
                    db.SaveChanges();

                    mesaj = "successRecord";
                    TempData["mesaj"] = mesaj;
                    mesaj = "";
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

>>>>>>> 7c227c0713be66b688f9075539e8798a6d090bb9
>>>>>>> 4ca5a5afe9c7ab2e2ea38648c32549d06ba9e221
                }
            }
            catch(Exception exception) // Beklenmedik durumlar burada toplanır. Sunucu hatası vs.
            {
                mesaj = "errorServer"; // Sunucu hatası!
                TempData["mesaj"] = mesaj;
                mesaj = "";

                model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
                return RedirectToAction("Index", "KullaniciyaUrunAtama");

            }
            model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
            return RedirectToAction("Index", "KullaniciyaUrunAtama");

        }
        
        public ActionResult ParitalDepo() // Depo tablosunda ki ürünleri lister.
        {
            model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList(); // Kullanıma uygun olan cihazları listememizi sağlar.
            return PartialView(model);
        }
    }
}