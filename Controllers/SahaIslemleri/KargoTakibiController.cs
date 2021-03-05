using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SahaIslemleri
{
    public class KargoTakibiController : Controller
    {
        // GET: KargoTakibi
        [Route("KargoTakibi")]
        public ActionResult Index()
        {
            return View();
        }
    }
}