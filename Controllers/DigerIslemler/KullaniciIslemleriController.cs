using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DigerIslemler
{
    public class KullaniciIslemleriController : Controller
    {
        // GET: KullaniciIslemleri
        [Route("KullaniciIslemleri")]
        public ActionResult Index()
        {
            return View();
        }
    }
}