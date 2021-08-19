using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        [Route("Main")]
        public ActionResult Index()
        {
            return View();
        }
    }
}