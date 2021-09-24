using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class ArizaBildirimiController : Controller
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2(); // Veritabanı referans nesnemiz
        cihazDetay model = new cihazDetay(); // Model için referans nesnesi tanımlaması
        String mesaj = ""; // İşlem sonucunda ki mesajı saklayacağız.

        // GET: ArizaBildirimi
        [Route("ArizaBildirimi")]
        public ActionResult Index()
        {
            return View();
        }

        // POST: ArizaBildirimi
        [HttpPost]
        [Route("ArizaBildirimi")]
        public ActionResult Index(string searchString) // Cihaz aramayı sağlar
        {
            try
            {
                Depo kayit = db.Depo.Where(k => k.envNo == searchString && k.kullanim == "aktif").FirstOrDefault(); // Envanter numarası ve searchString değeri ile eşleşen Depo tablosundaki kayıtları döndürür.
                Depo kayitSeriNo = db.Depo.Where(k => k.seriNo == searchString && k.kullanim == "aktif").FirstOrDefault(); // Seri numarası ve searchString değeri ile eşleşen Depo tablosundaki kayıtları döndürür.

                if (kayit != null) // Envanter numarası ile eşleşen kayıt varsa
                {

                    // Depo kayıtları null değer kontrolü
                    #region depoNullKontrol

                    if (kayit.cihazTuruId == null)
                        kayit.cihazTuruId = "";

                    if (kayit.cihazModeliId == null)
                        kayit.cihazModeliId = "";

                    if (kayit.envNo == null)
                        kayit.envNo = "";

                    if (kayit.seriNo == null)
                        kayit.seriNo = "";

                    if (kayit.garantiBas == null)
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

                    String cihazDurumu = "DEPODA";

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

                    if (model.durum == "TAMIRDE")
                    {
                        mesaj = "findRecordTamirde"; // Cihaz durumu TAMIRDE
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        cihazDurumu = "TAMIRDE";
                    }
                    else if (model.durum == "ARIZALI")
                    {
                        mesaj = "findRecordAriza"; // Cihaz durumu ARIZALI
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        cihazDurumu = "ARIZALI";
                    }

                    else if (model.durum == "HURDA")
                    {
                        mesaj = "findRecordHurda"; // Cihaz durumu HURDA
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        cihazDurumu = "HURDA";
                    }
                    else if (model.durum == "DEPODA")
                    {
                        mesaj = "findRecord"; // Cihaz durumu DEPODA
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        cihazDurumu = "DEPODA";
                    }
                    else if (model.durum == "BAGIS")
                    {
                        mesaj = "findRecordBagıs"; // Cihaz durumu BAGIS
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        cihazDurumu = "BAGIS";
                    }

                    else if (model.durum != "ARIZALI" || model.durum != "BAGIS" || model.durum != "TAMIRDE" || model.durum != "HURDA" || model.durum != "DEPODA")
                    {
                        mesaj = "deviceUndefined"; // Cihaz durumu tanımsız!
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        cihazDurumu = "UNDEFINE";
                    }
                    model.durum = cihazDurumu; // Hatalı kayıtlar için kontrol
                    return View(model);

                }
                else if (kayit == null)
                {
                    if (kayitSeriNo != null)
                    {
                        // Depo kayıtları null değer kontrolü
                        #region depoNullKontrol

                        if (kayitSeriNo.cihazTuruId == null)
                            kayitSeriNo.cihazTuruId = "";

                        if (kayitSeriNo.cihazModeliId == null)
                            kayitSeriNo.cihazModeliId = "";

                        if (kayitSeriNo.envNo == null)
                            kayitSeriNo.envNo = "";

                        if (kayitSeriNo.seriNo == null)
                            kayitSeriNo.seriNo = "";

                        if (kayitSeriNo.garantiBas == null)
                            kayitSeriNo.garantiBas = "";

                        if (kayitSeriNo.durum == null)
                            kayitSeriNo.durum = "";

                        if (kayitSeriNo.islemZaman == null)
                            kayitSeriNo.islemZaman = "";

                        if (kayitSeriNo.islemiYapan == null)
                            kayitSeriNo.islemiYapan = "";

                        if (kayitSeriNo.kullanim == null)
                            kayitSeriNo.kullanim = "";

                        if (kayitSeriNo.aciklama == null)
                            kayitSeriNo.aciklama = "";

                        if (kayitSeriNo.sifirIkinciEl == null)
                            kayitSeriNo.sifirIkinciEl = "";

                        #endregion //

                        String cihazDurumu = "DEPODA";

                        model = new cihazDetay() // Dönen kaydı modele ekliyoruz
                        {
                            cihazTuruID = kayitSeriNo.cihazTuruId.ToString(),
                            cihazModeliId = kayitSeriNo.cihazModeliId.ToString(),
                            envNo = kayitSeriNo.envNo.ToString(),
                            seriNo = kayitSeriNo.seriNo.ToString(),
                            garantiBas = kayitSeriNo.garantiBas.ToString(),
                            durum = kayitSeriNo.durum.ToString(),
                            islemZaman = kayitSeriNo.islemZaman.ToString(),
                            islemiYapan = kayitSeriNo.islemiYapan.ToString(),
                            kullanim = kayitSeriNo.kullanim.ToString(),
                            aciklama = kayitSeriNo.aciklama.ToString(),
                            sifirIkinciEl = kayitSeriNo.sifirIkinciEl.ToString()
                        };

                        if (model.durum == "TAMIRDE")
                        {
                            mesaj = "findRecordTamirde"; // Cihaz durumu TAMIRDE
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                            cihazDurumu = "TAMIRDE";
                        }
                        else if (model.durum == "ARIZALI")
                        {
                            mesaj = "findRecordAriza"; // Cihaz durumu ARIZALI
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                            cihazDurumu = "ARIZALI";
                        }

                        else if (model.durum == "HURDA")
                        {
                            mesaj = "findRecordHurda"; // Cihaz durumu HURDA
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                            cihazDurumu = "HURDA";
                        }
                        else if (model.durum == "DEPODA")
                        {
                            mesaj = "findRecord"; // Cihaz durumu DEPODA
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                            cihazDurumu = "DEPODA";
                        }
                        else if (model.durum == "BAGIS")
                        {
                            mesaj = "findRecordBagıs"; // Cihaz durumu BAGIS
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                            cihazDurumu = "BAGIS";
                        }

                        else if (model.durum != "ARIZALI" || model.durum != "BAGIS" || model.durum != "TAMIRDE" || model.durum != "HURDA" || model.durum != "DEPODA")
                        {
                            mesaj = "deviceUndefined"; // Cihaz durumu tanımsız!
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                            cihazDurumu = "UNDEFINE";
                        }
                        model.durum = cihazDurumu; // Hatalı kayıtlar için kontrol
                        return View(model);
                    }
                    else if (kayitSeriNo == null)
                    {
                        mesaj = "noRecord"; // Kayıt yok!
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                        return View();
                    }
                }

                else // Olası hatalı durumlar, kayıt başarısız!
                {
                    TempData["mesaj"] = "false";
                    return View();
                }
                return View();
            }
            catch (Exception) // Beklenmedik durumlar burada toplanır. Sunucu hatası vs.
            {
                mesaj = "errorServer"; // Sunucu hatası!
                TempData["mesaj"] = mesaj;
                mesaj = "";

                return View();
            }
        }

        // POST: ArizaKayit
        [HttpPost]
        [Route("ArizaKayit")]
        public ActionResult ArizaKayit(Depo kayit, FormCollection form) // Form alanlarında ki veriler Depo tablosuna kaydedilir. 
        {
            try
            {
                // Form alanlarının boş olup olmadığını kontrol eder
                if (form["envNo"] == "" || form["cihazModeliId"] == "" || form["seriNo"] == "" || form["garantiBas"] == "" || form["durum"] == "" || form["aciklama"] == "" || form["cihazTuruId"] == "")
                {
                    mesaj = "formEmpty";
                    TempData["mesaj"] = mesaj; // Form alanlarını doldurun hatası View alanına yönlendirilir.
                    mesaj = "";

                    return RedirectToAction("Index", "ArizaBildirimi"); // ArizaBildirimi sayfasına yönlendirir.
                }
                if (ModelState.IsValid) // Form alanları doğrulandı ise bu blok çalışır.
                {

                    var kayitEnvNo = db.Depo.Where(x => x.envNo == kayit.envNo && x.kullanim == "aktif").FirstOrDefault();
                    var kayitSeriNo = db.Depo.Where(k => k.seriNo == kayit.seriNo && k.kullanim == "aktif").FirstOrDefault(); // Seri numarası ve searchString değeri ile eşleşen Depo tablosundaki kayıtları döndürür.

                    if (kayitEnvNo != null) // Durum ve Açıklama değerleri güncellenir.
                    {
                        if (kayit.seriNo == kayitEnvNo.seriNo)
                        {
                            kayitEnvNo.durum = kayit.durum;

                            #region depoNullKontrol

                            if (kayit.cihazTuruId == null)
                                kayit.cihazTuruId = "";

                            if (kayit.cihazModeliId == null)
                                kayit.cihazModeliId = "";

                            if (kayit.envNo == null)
                                kayit.envNo = "";

                            if (kayit.seriNo == null)
                                kayit.seriNo = "";

                            if (kayit.garantiBas == null)
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


                            if (kayit.durum == "HURDA")
                            {
                                kayitEnvNo.kullanim = "pasif";
                            }
                            
                            kayitEnvNo.aciklama = kayit.aciklama;
                            db.Entry(kayitEnvNo).State = EntityState.Modified;
                            db.SaveChanges();

                            mesaj = "successRecord";
                            TempData["mesaj"] = mesaj;
                            mesaj = "";
                        }                   
                    }
                    else if (kayitEnvNo == null)
                    {
                        mesaj = "noRecord"; // Sunucu hatası!
                        TempData["mesaj"] = mesaj;
                        mesaj = "";
                    }
                }
            }
            catch (Exception exception) // Beklenmedik durumlar burada toplanır. Sunucu hatası vs.
            {
                mesaj = "errorServer"; // Sunucu hatası!
                TempData["mesaj"] = mesaj;
                mesaj = "";

                return RedirectToAction("Index", "ArizaBildirimi"); // ArizaBildirimi sayfasına yönlendirir.

            }
            return RedirectToAction("Index", "ArizaBildirimi"); // ArizaBildirimi sayfasına yönlendirir.

        }

    }
}