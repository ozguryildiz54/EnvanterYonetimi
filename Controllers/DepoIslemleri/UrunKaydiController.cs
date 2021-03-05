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
        envanterTakipWebEntities db = new envanterTakipWebEntities();
        // GET: UrunKaydi

        [HttpGet]
        [Route("UrunKaydi")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("UrunKaydi")]
        public ActionResult Index(Depo kayit)
        {
            if (ModelState.IsValid)
            {
                db.Depoes.Add(kayit);
                db.SaveChanges();
                ViewBag.Message = "Ürün Kaydedildi!";
            }
            return View();
        }

    }
}