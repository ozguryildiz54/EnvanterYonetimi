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
        
        // GET: UrunKaydi
        [HttpGet]
        [Route("UrunKaydi")] //Url yönlendirmesi; UrunKaydi sayfası bu yönlendirme ile çalıştırılır.
        public ActionResult Index() // Sayfa yüklendiğinde çalıştırılacak olan blok.
        {
            List<CihazTuru> CihazTurleri = db.CihazTuru.ToList(); // CihazTurleri listeye basılır
            ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip"); // Cihaz türleri basılan liste ile View alanına aktarılır.
            return View();
        }

        [Route("cihazTuruGetir")] //Url yönlendirmesi; cihazTuruGetir methodu bu yönlendirme ile çalıştırılır.
        public JsonResult cihazTuruGetir(int cihazTuruId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Modeller> Modeller = db.Modeller.Where(x => x.cihazTuruId == cihazTuruId).ToList(); // Seçilen cihaz türü ile eşleşen cihaz modelleri getirilir.
            return Json(Modeller, JsonRequestBehavior.AllowGet); // Modeller View alanına aktarılır.
        }

        [HttpPost]
        [Route("UrunKaydi")] //Url yönlendirmesi; UrunKaydi sayfasının sunucuya veri göndereceği method.
        public ActionResult Index(Depo kayit) // Depo tablosunun tipinde bir referans nesnesi parametre olarak tetiklenir.
        {
            List<CihazTuru> CihazTurleri = db.CihazTuru.ToList(); // CihazTurleri listeye basılır
            String message = ""; // İşlem sonucu bu değişkende saklanır.

            try
            {
                if (ModelState.IsValid)
                {
                    String kontrol = ""; // Kayıtlı envanterNo ve kayıtlı seriNo kontrolü için kullanacağımız değişkenimiz

                    kontrol = kayit.envNo.Trim(); // Form alanında arayıp bilgileri yüklenen cihazın envanter numarası
                    Depo envNoKayit = db.Depo.Where(k => k.envNo == kontrol).FirstOrDefault(); // Envanter numarası ve kontrol değeri ile eşleşen Depo tablosundaki kayıtları döndürür.

                    if (envNoKayit != null) // Envanter numarası ile eşleşen kayıt varsa
                    {
                        if (envNoKayit.kullanim == "aktif") // Kayıt varsa işlem başarısız
                        {
                            message = "findEnvNo"; // Kayıt var!
                            TempData["mesaj"] = message;
                            message = "";
                        }
                        else if (envNoKayit.kullanim == "pasif") // Kayıt var ancak kayıt silinmiş yani pasif değer ise kayıt yapılabilir
                        {
                            kontrol = kayit.seriNo.Trim(); // Form alanında arayıp bilgileri yüklenen cihazın seri numarası
                            Depo seriNoKayit = db.Depo.Where(k => k.seriNo == kontrol).FirstOrDefault(); // Seri numarası ve kontrol değeri ile eşleşen Depo tablosundaki kayıtları döndürür.

                            if (seriNoKayit != null) // Seri numarası ile eşleşen kayıt varsa
                            {
                                if (seriNoKayit.kullanim == "pasif") // Kayıt mevcut ancak silinmiş yani o kayıt pasif edilmiş
                                {
                                    kayit.islemZaman = DateTime.Now.ToString();
                                    kayit.islemiYapan = User.Identity.Name; // İşlemi yapan operatör
                                    kayit.kullanim = "aktif";
                                    db.Depo.Add(kayit); // Kayıt eklenir
                                    db.SaveChanges(); // Veritabanında ki değişiklikler kaydedilir.
                                    TempData["mesaj"] = "true";
                                }
                                else if (seriNoKayit.kullanim == "aktif") // Kayıt mevcut
                                {
                                    message = "findSeriNo"; // Kayıt var!
                                    TempData["mesaj"] = message;
                                    message = "";
                                }
                                else // Olası hatalı durumlar, kayıt başarısız!
                                {
                                    TempData["mesaj"] = "false";
                                }

                            }
                            else if (seriNoKayit == null) // Seri numarası ile eşleşen kayıt yoksa, yeni cihaz kaydı yapılabilir.
                            {
                                kayit.islemZaman = DateTime.Now.ToString();
                                kayit.islemiYapan = User.Identity.Name; // İşlemi yapan operatör
                                kayit.kullanim = "aktif";
                                db.Depo.Add(kayit); // Kayıt eklenir
                                db.SaveChanges(); // Veritabanında ki değişiklikler kaydedilir.
                                TempData["mesaj"] = "true";
                            }
                            else // Olası hatalı durumlar, kayıt başarısız!
                            {
                                TempData["mesaj"] = "false";
                            }
                        }

                    }
                    else if (envNoKayit == null) // Envanter numarası ile eşleşen kayıt yoksa
                    {
                        kontrol = kayit.seriNo.Trim(); // Form alanında arayıp bilgileri yüklenen cihazın seri numarası
                        Depo seriNoKayit = db.Depo.Where(k => k.seriNo == kontrol).FirstOrDefault(); // Seri numarası ve kontrol değeri ile eşleşen Depo tablosundaki kayıtları döndürür.

                        if (seriNoKayit!=null) // Seri numarası ile eşleşen kayıt varsa
                        {
                            if (seriNoKayit.kullanim == "pasif") // Kayıt mevcut ancak silinmiş yani o kayıt pasif edilmiş
                            {
                                kayit.islemZaman = DateTime.Now.ToString();
                                kayit.islemiYapan = User.Identity.Name; // İşlemi yapan operatör
                                kayit.kullanim = "aktif";
                                db.Depo.Add(kayit); // Kayıt eklenir
                                db.SaveChanges(); // Veritabanında ki değişiklikler kaydedilir.
                                TempData["mesaj"] = "true";
                            }
                            else if (seriNoKayit.kullanim == "aktif") // Kayıt mevcut
                            {
                                message = "findSeriNo"; // Kayıt var!
                                TempData["mesaj"] = message;
                                message = "";
                            }
                            else // Olası hatalı durumlar, kayıt başarısız!
                            {
                                TempData["mesaj"] = "false";
                            }
                        }
                        else if (seriNoKayit == null) // Seri numarası ile eşleşen kayıt yoksa, yeni cihaz kaydı yapılabilir.
                        {
                            kayit.islemZaman = DateTime.Now.ToString();
                            kayit.islemiYapan = User.Identity.Name; // İşlemi yapan operatör
                            kayit.kullanim = "aktif";
                            db.Depo.Add(kayit); // Kayıt eklenir
                            db.SaveChanges(); // Veritabanında ki değişiklikler kaydedilir.
                            TempData["mesaj"] = "true";
                        }
                        else // Olası hatalı durumlar, kayıt başarısız!
                        {
                            TempData["mesaj"] = "false";
                        }
                    }
                    else // Olası hatalı durumlar, kayıt başarısız!
                    {
                        TempData["mesaj"] = "false";

                    }
                    ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip");
                }
                ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip");
            }
            catch // Olası hatalı durumlar, kayıt başarısız!
            {
                TempData["mesaj"] = "false";
                ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip");
                return RedirectToAction("Index", "UrunKaydi"); // UrunKaydi sayfasına yönlendirir.
            }

            ViewBag.CihazTurleri = new SelectList(CihazTurleri, "cihazTuruId", "cihazTip");
            return RedirectToAction("Index", "UrunKaydi"); // UrunKaydi sayfasına yönlendirir.
        }
    }
}