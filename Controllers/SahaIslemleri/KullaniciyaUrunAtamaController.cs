using EnvanterYonetimi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SahaIslemleri
{
    public class KullaniciyaUrunAtamaController : Controller
    {
        envanterTakipWebEntities db = new envanterTakipWebEntities();
        String mesaj="";
        // GET: KullaniciyaUrunAtama
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index(string searchString)
        {
            using (envanterTakipWebEntities db = new envanterTakipWebEntities())
            {
                var sonuc = from s in db.Depo
                               select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    sonuc = sonuc.Where(s => s.envNo.Equals(searchString));
                    
                    if (sonuc.Count() == 0)
                    {
                        mesaj = "false"; // Kayıt yok!

                    }
                    if (sonuc.Count() > 0)
                    {
                        mesaj = "true"; // Kayıt yok!

                    }
                    ViewBag.Message = mesaj;
                    mesaj = "";
                    return View(sonuc.FirstOrDefault(s => s.envNo == searchString));

                }
                return View();
            }
        }
    }
}