//using EnvanterYonetimi.Models.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace EnvanterYonetimi.Controllers.DepoIslemleri
//{
//    public class UrunKaydiController : Controller
//    {​​​​​​​
//        envanterTakipWebEntities db = new envanterTakipWebEntities();


//        GET: UrunKaydi
//       [HttpGet]
//       [Route("UrunKaydi")]
//        public ActionResult Index()
//        {​​​​​​​
//            return View();
//        }​​​​​​​



//        [HttpPost]
//        [Route("UrunKaydi")]
//        public ActionResult Index(Depo kayit)
//        {​​​​​​​
//            if (ModelState.IsValid)
//            {
//                db.Depoes.Add(kayit);
//                db.SaveChanges();
//                ViewBag.Message = "Ürün kaydedildi!";
//            }


//            return View();
//        }​​​​​​​
//    }​​​​​​​






//}

using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class UrunKaydiController : Controller
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2();
        // GET: UrunKaydi
        [HttpGet]
        [Route("UrunKaydi")]
        public ActionResult Index()
        {
            //List<SelectListItem> cihazTurleri = (from i in db.CihazTuru.ToList()
            //                                        select new SelectListItem
            //                                        {
            //                                            Text=i.cihazTip,
            //                                            Value=i.cihazTuruId.ToString()
            //                                        }).ToList();
            //ViewBag.cihazTuru = cihazTurleri;

            //List<SelectListItem> cihazModelleri = (from i in db.Modeller.ToList()
            //                                     select new SelectListItem
            //                                     {
            //                                         Text = i.model,
            //                                         Value = i.modelId.ToString()
            //                                     }).ToList();
            //ViewBag.model = cihazModelleri;

            //cihazModel cm = new cihazModel();
            //cm.CihazTuru = db.CihazTuru.ToList();
            //cm.CihazModelleri = db.Modeller.ToList();

            //return View(cm);

            List<CihazTuru> CihazTurleri = db.CihazTuru.ToList();
            ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip");
            return View();

        }

        [Route("GetStateList")]
        public JsonResult GetStateList(int cihazTuruId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Modeller> Modeller = db.Modeller.Where(x => x.cihazTuruId == cihazTuruId).ToList();
            return Json(Modeller, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [Route("UrunKaydi")]
        public ActionResult Index(Depo kayit)
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
        }

        //[HttpPost]
        //public JsonResult SelectGetir(int? cihazTuruId, string tip)
        //{
        //    //EntityFramework ile veritabanı modelimizi oluşturduk ve
        //    //IlilceDBEntities ile db nesnesi oluşturduk.
        //    //IlilceDBEntities db = new IlilceDBEntities();
        //    //geriye döndüreceğim sonucListim
        //    List<SelectListItem> sonuc = new List<SelectListItem>();
        //    List<SelectListItem> sonuc2 = new List<SelectListItem>();

        //    //bu işlem başarılı bir şekilde gerçekleşti mi onun kontrolunnü yapıyorum
        //    bool basariliMi = true;
        //    try
        //    {
        //        switch (tip)
        //        {
        //            case "cihazTuruGetir":
        //                //veritabanımızdaki iller tablomuzdan illerimizi sonuc değişkenimze atıyoruz
        //                foreach (var cihaz in db.CihazTuru.ToList())
        //                {
        //                    sonuc.Add(new SelectListItem
        //                    {
        //                        Text = cihaz.cihazTip,
        //                        Value = cihaz.cihazTuruId.ToString()
        //                    });
        //                }
        //                break;
        //            case "cihazModeliGetir":
        //                //ilcelerimizi getireceğiz ilimizi selecten seçilen ilID sine göre 
        //                foreach (var model in db.Modeller.Where(cihaz => cihaz.cihazTuruId == cihazTuruId).ToList())
        //                {
        //                    sonuc2.Add(new SelectListItem
        //                    {
        //                        Text = model.model,
        //                        Value = model.cihazTuruId.ToString()
        //                    });
        //                }
        //                break;

        //            default:
        //                break;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //hata ile karşılaşırsak buraya düşüyor
        //        basariliMi = false;
        //        sonuc = new List<SelectListItem>();
        //        sonuc.Add(new SelectListItem
        //        {
        //            Text = "Bir hata oluştu :(",
        //            Value = "Default"
        //        });

        //    }
        //    //Oluşturduğum sonucları json olarak geriye gönderiyorum
        //    return Json(new { ok = basariliMi, text = sonuc });
        //}

    }
}