using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class DepoKaydiController : Controller
    {
        // GET: DepoKaydi
        [Route("DepoKaydi")]
        public ActionResult Index()
        {
            return View();
        }
    }
}