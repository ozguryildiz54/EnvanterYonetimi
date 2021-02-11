using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvanterYonetimi.Models.Entity;

namespace EnvanterYonetimi.Controllers
{
    public class CihazTuruController : Controller
    {
        // GET: CihazTuru
        envanterTakipWebEntities database = new envanterTakipWebEntities(); // Veritabanında ki tablolara erişim için kullanılır.
        public ActionResult Index()
        {
            var cihazTuruSonuclar = database.CihazTuru.ToList();
            return View(cihazTuruSonuclar);
        }
    }
}