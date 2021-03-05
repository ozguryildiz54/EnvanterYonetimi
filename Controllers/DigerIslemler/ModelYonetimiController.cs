using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers.DigerIslemler
{
    public class ModelYonetimiController : Controller
    {
        // GET: ModelYonetimi
        [Route("ModelYonetimi")]
        public ActionResult Index()
        {
            return View();
        }
    }
}