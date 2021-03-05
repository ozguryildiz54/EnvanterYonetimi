using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SahaIslemleri
{
    public class UrunKullanicisiDegistirController : Controller
    {
        // GET: UrunKullanicisiDegistir
        [Route("UrunKullanicisiDegistir")]
        public ActionResult Index()
        {
            return View();
        }
    }
}