using System;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace EnvanterYonetimi.Controllers
{
    public class LoginController : Controller
    {
        #region LoginUserCheck

            public bool ValidateUser(string userName, string password)
            {
                bool validation;
                try
                {
                    LdapConnection ldc = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                    NetworkCredential nc = new NetworkCredential(userName, password, "AKGIDA");
                    ldc.Credential = nc;
                    ldc.AuthType = AuthType.Negotiate;
                    ldc.Bind(nc); // user has authenticated at this point, as the credentials were used to login to the dc.
                    validation = true;
                }
                catch (LdapException)
                {
                    validation = false;
                }
                return validation;
        }
        #endregion

        // GET: Login
        //[Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        //[Route("")]
        [HttpPost]
        public ActionResult Index(string eposta, string sifre)
        {
            ViewData["mesaj"] = "calismiyor";
            eposta = Request.Form["email"];
             sifre = Request.Form["pass"];
            TempData["kullaniciAdi"] = eposta;
            String sonuc = "kod çalışmıyor";
            sonuc = ValidateUser(eposta, sifre).ToString();
            ViewData["sonuc"] = sonuc;
            if (sonuc == "True")
            {
                ViewData["mesaj"] = "true";
                //Response.Redirect("/Main", true);
                Response.Redirect("/Main/Index", true);
            }
            ViewData["mesaj"] = "false";
            return View();
        }
       
    }
}