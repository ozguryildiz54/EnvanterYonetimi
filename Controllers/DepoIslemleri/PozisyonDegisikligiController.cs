using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class PozisyonDegisikligiController : Controller
    {
        // GET: PozisyonDegisikligi
        [Route("PozisyonDegisikligi")]
        public ActionResult Index()
        {
            return View();
        }
    }
}