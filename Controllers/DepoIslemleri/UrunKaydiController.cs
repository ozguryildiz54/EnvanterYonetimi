using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class UrunKaydiController : Controller
    {
        // GET: UrunKaydi
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string degiskenler)
        {
            
            return View();
        }
    }
}