using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.KullaniciProfil
{
    public class OperatorAyarlariController : Controller
    {
        // GET: OperatorAyarlari
        [Route("OperatorAyarlari")]
        public ActionResult Index()
        {
            return View();
        }
    }
}