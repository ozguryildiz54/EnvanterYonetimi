using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EnvanterYonetimi.Controllers.KullaniciProfil
{
    public class CikisController : Controller
    {
        // GET: Cikis
        [Route("Cikis")] // Cikis sayfasına yönlendirerek bu bloğu çalıştırır.
        public ActionResult Index()
        {
            FormsAuthentication.SignOut(); // Çerezlerde ki oturum verileri kaldırılır.
            return View();
        }
    }
}