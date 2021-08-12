using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DigerIslemler
{
    public class OperatorIslemleriController : Controller
    {
        // GET: OperatorIslemleri
        [Route("OperatorIslemleri")]
        public ActionResult Index()
        {
            return View();
        }
    }
}