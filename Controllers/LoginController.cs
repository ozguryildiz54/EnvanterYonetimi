using System;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace EnvanterYonetimi.Controllers
{
    [AllowAnonymous] // Kullanıcı giriş kontrolünü bu sayfa için pas geçer yani bu sayfa login sayfası olduğu için buraya erişmek için kullanıcı girişi istemez

    public class LoginController : Controller
    {

        // Kullanıcı bilgisinin Active Directory üzerinden kontrolünün yapıldığı blok
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
                ldc.Bind(nc); // Kimlik bilgileri dc'de oturum açmak için kullanıldığından, bu noktada kullanıcı kimliği doğrulanmıştır.
                validation = true;
            }
            catch (LdapException) // Kullanıcı girişi başarısız ise validation değişkenimiz false olarak tetiklenir.
            {
                validation = false;
            }
            return validation;
        }
        #endregion

        // GET: Login
        [Route("")] //Url yönlendirmesi; bu yönlendirmeye göre web sayfasının adını yazdıktan sonra hiçbir alt sayfaya yönlendirmediğimizde çalışacak olan blok.
        [HttpGet]
        public ActionResult Index() // Sayfa yüklendiğinde çalışacak olan blok
        {
            return View();
        }

        [Route("")] //Url yönlendirmesi; bu yönlendirmeye göre web sayfasının adını yazdıktan sonra hiçbir alt sayfaya yönlendirmediğimizde çalışacak olan blok.
        [HttpPost]
        public ActionResult Index(string eposta, string sifre)
        {
            ViewData["mesaj"] = "Hata";
            eposta = Request.Form["email"]; // Kullanıcının girdiği email bilgisi
             sifre = Request.Form["pass"]; // Kullanıcının girdiği parola bilgisi
            TempData["kullaniciAdi"] = eposta;
            String sonuc = "Kod çalışmıyor";
            sonuc = ValidateUser(eposta, sifre).ToString();
            ViewData["sonuc"] = sonuc;
            if (sonuc == "True") // Kullanıcı girişi başarılı
            {
                ViewData["mesaj"] = "true";

                FormsAuthentication.SetAuthCookie(eposta, false); // Kullanıcı bilgisi çerezlere kaydedilir.
                Response.Redirect("/Main", true); // Giriş başarılı olduğundan /Main sayfasına yönlendirilir.
            }
            else // Kullanıcı girişi başarısız
            {
                ViewData["mesaj"] = "false";                
            }
            return View();
        }
       
    }
}