using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SahaIslemleri
{
    public class KullaniciyaUrunAtamaController : Controller
    {
        // GET: KullaniciyaUrunAtama
        [Route("KullaniciyaUrunAtama")]
        public ActionResult Index()
        {
            return View();
        }
    }
}