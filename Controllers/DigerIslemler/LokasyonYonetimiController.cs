using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DigerIslemler
{
    public class LokasyonYonetimiController : Controller
    {
        // GET: LokasyonYonetimi
        [Route("LokasyonYonetimi")]
        public ActionResult Index()
        {
            return View();
        }
    }
}