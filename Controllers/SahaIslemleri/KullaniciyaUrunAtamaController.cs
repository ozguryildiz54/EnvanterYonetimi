using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SahaIslemleri
{
    public class KullaniciyaUrunAtamaController : Controller
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2();
        String mesaj="";

        // GET: KullaniciyaUrunAtama
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index()
        {
            cihazDetay model = new cihazDetay();
            model.DepoGetir = db.Depo.Where(k=>k.durum=="DEPODA").ToList();
            return View(model);
        }
        [HttpPost]
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index(string searchString)
        {
            cihazDetay kk = new cihazDetay();
            try
            {
                Depo kayit = db.Depo.Where(k => k.envNo == searchString).FirstOrDefault();
                if (!(kayit == null))
                {
                    kk = new cihazDetay()
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
                        sifirIkinciEl = "asdad",
                        //iade = kayit.iade.ToString(),
                        //termin = kayit.termin.ToString(),
                    };

                    if (kk.durum != "DEPODA")
                    {
                        mesaj = "false"; // Kayıt yok!
                        ViewBag.Message = mesaj;
                        mesaj = "";

                        kk.DepoGetir = db.Depo.ToList();
                        return View(kk);
                    }

                    mesaj = "true"; // Kayıt var!
                    ViewBag.Message = mesaj;
                    mesaj = "";
                    kk.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList();
                    return View(kk);
                }
                mesaj = "error"; // Sunucu hatası!
                ViewBag.Message = mesaj;
                mesaj = "";
                kk.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList();
                return View(kk);
            }
            catch (Exception)
            {
                kk.DepoGetir = db.Depo.ToList();
                return View(kk);
            }
        }
        [HttpPost]
        [Route("kayit")]
        public ActionResult kayit(FormCollection form)
        {
            envanterTakipWebEntities2 db2 = new envanterTakipWebEntities2();
            cihazDetay kk = new cihazDetay();

            Saha saha = new Saha();
            String mesaj = "";
            try
            {
                if (form["kullaniciAdi"] == "" || form["kullaniciSoyadi"] == "" || form["sirketId"] == "" || form["lokasyonId"] == "" || form["envNo"] == "" || form["cihazModeliId"] == "" || form["seriNo"] == "" || form["garantiBas"] == "" || form["durum"] == "" || form["aciklama"] == "" || form["sifir_ikinci_el"] == "" || form["cihazTuruId"] == "")
                {

                    mesaj = "error3";
                    ViewBag.Message = mesaj;
                    TempData["mesaj"] = mesaj;
                    kk.DepoGetir = db.Depo.ToList();
                    return RedirectToAction("Index", "KullaniciyaUrunAtama");
                }

                if (ModelState.IsValid)
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
                    saha.sifir_ikinci_el = form["sifir_ikinci_el"].Trim();
                    saha.operatorId = User.Identity.Name;
                    saha.islemZaman = DateTime.Now.ToString();
                    saha.kullanim = "aktif";
                    saha.cihazTuruId = form["cihazTuruId"].Trim();
                    
                    
                    db2.Saha.Add(saha);
                    db2.SaveChanges();
                    mesaj = "true2";
                    ViewBag.Message = mesaj;
                    TempData["mesaj"] = mesaj;
                }
            }
            catch(Exception exception)
            {
                mesaj = "error2";
                ViewBag.Message = mesaj;
                mesaj = "";
                TempData["mesaj"] = mesaj;
                cihazDetay kk3 = new cihazDetay();
                kk3.DepoGetir = db.Depo.ToList();
                return RedirectToAction("Index", "KullaniciyaUrunAtama");

            }
            kk.DepoGetir = db.Depo.ToList();
            return RedirectToAction("Index", "KullaniciyaUrunAtama");

        }
        public ActionResult ParitalDepo()
        {
            cihazDetay model = new cihazDetay();
            model.DepoGetir = db.Depo.Where(k => k.durum == "DEPODA").ToList();
            return PartialView(model);
        }
    }
}