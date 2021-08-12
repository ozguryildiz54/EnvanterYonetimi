using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DepoIslemleri
{
    public class IstenCikmaController : Controller
    {
        // GET: IstenCikma
        [Route("IstenCikma")]
        public ActionResult Index()
        {
            return View();
        }
    }
}