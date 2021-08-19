using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.SistemKayitlari
{
    public class SistemKayitlariController : Controller
    {
        // GET: SistemKayitlari
        [Route("SistemKayitlari")]
        public ActionResult Index()
        {
            return View();
        }
    }
}