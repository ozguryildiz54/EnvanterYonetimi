using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.KullaniciProfil
{
    public class CikisController : Controller
    {
        // GET: Cikis
        [Route("Cikis")]
        public ActionResult Index()
        {
            return View();
        }
    }
}