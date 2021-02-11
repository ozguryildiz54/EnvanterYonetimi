using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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
        [HttpGet]
        public ActionResult Index()
        {

            String sonuc = "kod çalışmıyor";
            sonuc = ValidateUser("ozgdfgdfgur.yildiz", "Kasim.hdedd2019").ToString();
            ViewData["sonuc"] = sonuc;
            return View();
        }

        //[HttpPost]
        //public string PostLogin(string email, string pass)
        //{
        //    String sonuc = "kod çalışmıyor";
        //    sonuc = ValidateUser("ozgur.yildiz", "Kasim.2019").ToString();
        //    ViewData["sonuc"] = sonuc;
        //    return sonuc;
        //}

        ////OU=AKGIDA,DC=akgida,DC=com,DC=tr
        ////LDAP://www.akgida.com.tr/OU=AKGIDA,O=ON
    }
}