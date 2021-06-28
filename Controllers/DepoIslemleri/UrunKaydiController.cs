using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class UrunKaydiController : Controller
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2(); // Entity Framework ile veritabanı bağlantısı
        //modelData mData = new modelData();
        String cihazTId="1";
        String modelTId="1";
        // GET: UrunKaydi
        [HttpGet]
        [Route("UrunKaydi")] //Url yönlendirmesi; UrunKaydi sayfası bu yönlendirme ile çalıştırılır.
        public ActionResult Index() // Sayfa yüklendiğinde çalıştırılacak olan blok.
        {
            List<CihazTuru> CihazTurleri = db.CihazTuru.ToList();
            ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip");
            return View();
            //var cihazTurleri = new List<SelectListItem>();

            //var modeller = new List<SelectListItem>();


            //db.CihazTuru.OrderBy(s => s.cihazTip).ToList().ForEach(s => cihazTurleri.Add(new SelectListItem
            //{
            //    Text = s.cihazTip,
            //    Value = s.cihazTuruId.ToString()
            //}));
            //int ID = Convert.ToInt32(cihazTurleri[0].Value);
            //db.Modeller.OrderBy(s => s.model).Where(s => s.cihazTuruId == ID).ToList().ForEach(s => modeller.Add(new SelectListItem
            //{
            //    Text = s.model,
            //    Value = s.modelId.ToString()
            //}));
            //int ModelID = Convert.ToInt32(modeller[0].Value);

            //var model = new cihazDetay
            //{
            //    cihazTurleri = cihazTurleri,
            //    modeller = modeller,
            //    cihazTuruId = ID,
            //    modelId= ModelID
            //};

            //// Sayfa yüklendiğinde cihaz türlerini veritabanından çekip Select etiketi içine aktarmak için verileri ViewBag içine aktarıyoruz.
            ////List<CihazTuru> CihazTuru = db.CihazTuru.ToList();
            ////ViewBag.CihazTuru = new SelectList(CihazTuru, "cihazTuruId", "cihazTip"); // CihazTuru tablosunda ki cihazTuruId ve cihazTip niteliklerini seçiyoruz.
            //return View(model);
        }

        [Route("cihazTuruGetir")] //Url yönlendirmesi; cihazTuruGetir methodu bu yönlendirme ile çalıştırılır.
        //public JsonResult cihazTuruGetir(int cihazTuruId) // Seçili cihaz türünün id değerine göre cihaz modelini listeleyip Json olarak döndürür.
        //{
        //      db.Configuration.ProxyCreationEnabled = false;
        //    List<Modeller> Modeller = db.Modeller.Where(x => x.cihazTuruId == cihazTuruId).ToList();
        //    return Json(Modeller, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult cihazTuruGetir(int cihazTuruId)
        {
            //int ID = Convert.ToInt32(cihazTuruId);

            //var modeller = db.Modeller.Where(s => s.cihazTuruId == ID).OrderBy(s => s.model).Select(s => new
            //{
            //    id = s.modelId,
            //    modelAdi = s.model
            //}).ToList();
            //cihazTId = ID.ToString();
            //modelTId = modeller[0].id.ToString();

            //return Json(modeller, JsonRequestBehavior.AllowGet);
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
                if (ModelState.IsValid)
                {
                    kayit.islemZaman = DateTime.Now.ToString();
                    kayit.islemiYapan = User.Identity.Name;
                    kayit.kullanim = "aktif";

                    db.Depo.Add(kayit);
                    db.SaveChanges();
                    mesaj = true;
                    ViewBag.Message = mesaj;
                }
            }
            catch
            {
                mesaj = false;
                ViewBag.Message = mesaj;
            }

            return View();
            //var cihazTurleri = new List<SelectListItem>();

            //var modeller = new List<SelectListItem>();
            //cihazDetay model=new cihazDetay();
            //Boolean mesaj; 
            //try
            //{
            //    if (ModelState.IsValid) // Model içerisinde tanımlanan doğrulama sınıfında ki kontrolleri sağlar. 
            //    {
            //        detay.cihazTuruId = Convert.ToInt32(cihazTId);
            //        detay.depo.cihazTuruId = cihazTId.ToString();
            //        detay.depo.cihazModeliId = modelTId.ToString();

            //        detay.depo.islemZaman = DateTime.Now.ToString(); // İşlem zamanı için şuan ki zamanı nesnemize atıyoruz.
            //        detay.depo.islemiYapan = User.Identity.Name; // İşlemi yapan kişi bilgisi için çerezlerden kullanıcı adını nesnemize atıyoruz.
            //        detay.depo.kullanim = "aktif"; // Her yeni kayıt değerimiz silme işlemi olmadığından aktif değeri ile saklanır.

            //        db.Depo.Add(detay.depo); // kayit nesnemiz Depo tablosuna yeni bir kayıt olarak eklenir. Tam olarak insert sorgusu ile aynı işi yapar.
            //        db.SaveChanges();
            //        mesaj = true; // Kayıt başarılı!
            //        ViewBag.Message = mesaj;
            //    }

            //    db.CihazTuru.OrderBy(s => s.cihazTip).ToList().ForEach(s => cihazTurleri.Add(new SelectListItem
            //    {
            //        Text = s.cihazTip,
            //        Value = s.cihazTuruId.ToString()
            //    }));
            //    int ID = Convert.ToInt32(cihazTurleri[0].Value);
            //    db.Modeller.OrderBy(s => s.model).Where(s => s.cihazTuruId == ID).ToList().ForEach(s => modeller.Add(new SelectListItem
            //    {
            //        Text = s.model,
            //        Value = s.modelId.ToString()
            //    }));


            //    model = new cihazDetay
            //    {
            //        cihazTurleri = cihazTurleri,
            //        modeller = modeller
            //    };

            //}
            //catch // Kayıt başarısız!
            //{
            //    mesaj = false;
            //    ViewBag.Message = mesaj;
            //}

            //return View(model);
        }
    }
}