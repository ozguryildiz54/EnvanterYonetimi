using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class BagisYapController : Controller
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2(); // Veritabanı referans nesnemiz
        cihazDetay model = new cihazDetay(); // Model için referans nesnesi tanımlaması
        String mesaj = ""; // İşlem sonucunda ki mesajı saklayacağız.

        // GET: BagisYap
        [Route("BagisYap")]
        public ActionResult Index()
        {
            return View();
        }

        // POST: BagisYap
        [HttpPost]
        [Route("BagisYap")]
        public ActionResult Index(string searchString) // Cihaz aramayı sağlar
        {
            try
            {
                String cihazDurumu = "DEPODA";

                // Envanter numarası ve searchString değeri ile eşleşen Depo tablosundaki aktif kayıtları döndürür.
                Depo envNoKayit = db.Depo.Where(k => k.envNo == searchString && k.kullanim=="aktif").FirstOrDefault(); 
               
                if (envNoKayit != null) // Envanter numarası ile eşleşen kayıt varsa
                {
                    // Depo kayıtları null değer kontrolü
                    #region depoNullKontrol

                    if (envNoKayit.cihazTuruId == null)
                        envNoKayit.cihazTuruId = "";

                    if (envNoKayit.cihazModeliId == null)
                        envNoKayit.cihazModeliId = "";

                    if (envNoKayit.envNo == null)
                        envNoKayit.envNo = "";

                    if (envNoKayit.seriNo == null)
                        envNoKayit.seriNo = "";

                    if (envNoKayit.garantiBas == null)
                        envNoKayit.garantiBas = "";

                    if (envNoKayit.durum == null)
                        envNoKayit.durum = "";

                    if (envNoKayit.islemZaman == null)
                        envNoKayit.islemZaman = "";

                    if (envNoKayit.islemiYapan == null)
                        envNoKayit.islemiYapan = "";

                    if (envNoKayit.kullanim == null)
                        envNoKayit.kullanim = "";

                    if (envNoKayit.aciklama == null)
                        envNoKayit.aciklama = "";

                    if (envNoKayit.sifirIkinciEl == null)
                        envNoKayit.sifirIkinciEl = "";

                    #endregion //
                    model = new cihazDetay() // Dönen kaydı modele ekliyoruz
                    {
                        cihazTuruID = envNoKayit.cihazTuruId.ToString(),
                        cihazModeliId = envNoKayit.cihazModeliId.ToString(),
                        envNo = envNoKayit.envNo.ToString(),
                        seriNo = envNoKayit.seriNo.ToString(),
                        garantiBas = envNoKayit.garantiBas.ToString(),
                        durum = envNoKayit.durum.ToString(),
                        islemZaman = envNoKayit.islemZaman.ToString(),
                        islemiYapan = envNoKayit.islemiYapan.ToString(),
                        kullanim = envNoKayit.kullanim.ToString(),
                        aciklama = envNoKayit.aciklama.ToString(),
                        sifirIkinciEl = envNoKayit.sifirIkinciEl.ToString()
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

                else if (envNoKayit == null)
                {
                    // Seri numarası ve searchString değeri ile eşleşen Depo tablosundaki kayıtları döndürür.
                    Depo kayitSeriNo = db.Depo.Where(k => k.seriNo == searchString && k.kullanim == "aktif").FirstOrDefault(); 
                    
                    if (kayitSeriNo != null) // Seri numarası ile eşleşen kayıt varsa
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

        // POST: BagisYap
        [HttpPost]
        [Route("BagisYapKayit")]
        public ActionResult BagisYapKayit(Depo kayit, FormCollection form) // Form alanlarında ki veriler Depo tablosuna kaydedilir. 
        {
            try
            {
                // Form alanlarının boş olup olmadığını kontrol eder
                if (form["envNo"] == "" || form["cihazModeliId"] == "" || form["seriNo"] == "" || form["garantiBas"] == "" || form["durum"] == "" || form["aciklama"] == "" || form["cihazTuruId"] == "")
                {
                    mesaj = "formEmpty";
                    TempData["mesaj"] = mesaj; // Form alanlarını doldurun hatası View alanına yönlendirilir.
                    mesaj = "";

                    return RedirectToAction("Index", "BagisYap"); // ArizaBildirimi sayfasına yönlendirir.
                }
                if (ModelState.IsValid) // Form alanları doğrulandı ise bu blok çalışır.
                {

                    var kayitEnvNo = db.Depo.Where(x => x.envNo == kayit.envNo && x.kullanim == "aktif").FirstOrDefault();
                    var kayitSeriNo = db.Depo.Where(k => k.seriNo == kayit.seriNo && k.kullanim == "aktif").FirstOrDefault(); // Seri numarası ve searchString değeri ile eşleşen Depo tablosundaki kayıtları döndürür.

                    if (kayitEnvNo != null) // Durum ve Açıklama değerleri güncellenir.
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

                        if (kayit.durum == "BAGIS")
                        {
                            kayitEnvNo.kullanim = "pasif";
                        }
                        kayitEnvNo.durum = kayit.durum;
                        kayitEnvNo.aciklama = kayit.aciklama;
                        kayitEnvNo.kullanim = "pasif";

                        db.Entry(kayitEnvNo).State = EntityState.Modified;
                        db.SaveChanges();

                        mesaj = "successRecord";
                        TempData["mesaj"] = mesaj;
                        mesaj = "";

                        
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

                return RedirectToAction("Index", "BagisYap"); // ArizaBildirimi sayfasına yönlendirir.

            }
            return RedirectToAction("Index", "BagisYap"); // ArizaBildirimi sayfasına yönlendirir.

        }

    }
}