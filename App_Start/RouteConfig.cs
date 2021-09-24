using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnvanterYonetimi
{
    public class RouteConfig
    {
 
        /*
         * Sayfaların controller yönlendirilmeleri
         * 
         * Name: Controller içinde tanımlanır. Ör:  [Route("UrunKaydi")]
         * Url: Bu kısım ise View içinde herhangi bir yerde ki link vermek gibi veya 
         *      MainLayoutda ki navbar alanındaki gibi link verdiğimiz alanlarda tanımlanır.
         *
         * Web sayfamızda ki örnek olarak websiteadi.com/Main/Index şeklindeki sayfamızın yönlendirmesi "websiteadi.com/Main" şeklindedir.
         *
         */

        public static void RegisterRoutes(RouteCollection routes) 
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            
            routes.MapRoute( // Login/Index sayfamızın yönlendirmesi
                name: "",
                url: "",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute( // Main/Index sayfamızın yönlendirmesi
                name: "Main",
                url: "Main",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // ArizaBildirimi/Index sayfamızın yönlendirmesi
                name: "ArizaBildirimi",
                url: "ArizaBildirimi",
                defaults: new { controller = "ArizaBildirimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // ModelYonetimi/Index sayfamızın yönlendirmesi
                name: "ModelYonetimi",
                url: "ModelYonetimi",
                defaults: new { controller = "ModelYonetimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // LokasyonYonetimi/Index sayfamızın yönlendirmesi
                name: "LokasyonYonetimi",
                url: "LokasyonYonetimi",
                defaults: new { controller = "LokasyonYonetimi", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute( // OperatorAyarlari/Index sayfamızın yönlendirmesi
                name: "OperatorAyarlari",
                url: "OperatorAyarlari",
                defaults: new { controller = "OperatorAyarlari", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // SirketYonetimi/Index sayfamızın yönlendirmesi
                name: "SirketYonetimi",
                url: "SirketYonetimi",
                defaults: new { controller = "SirketYonetimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // CihazTuruYonetimi/Index sayfamızın yönlendirmesi
                name: "CihazTuruYonetimi",
                url: "CihazTuruYonetimi",
                defaults: new { controller = "CihazTuruYonetimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // AmortismanBildirimi/Index sayfamızın yönlendirmesi
                name: "AmortismanBildirimi",
                url: "AmortismanBildirimi",
                defaults: new { controller = "AmortismanBildirimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // BagisYap/Index sayfamızın yönlendirmesi
                name: "BagisYap",
                url: "BagisYap",
                defaults: new { controller = "BagisYap", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // DepoKaydi/Index sayfamızın yönlendirmesi
                name: "DepoKaydi",
                url: "DepoKaydi",
                defaults: new { controller = "DepoKaydi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // IstenCikma/Index sayfamızın yönlendirmesi
                name: "IstenCikma",
                url: "IstenCikma",
                defaults: new { controller = "IstenCikma", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute( // PozisyonDegisikligi/Index sayfamızın yönlendirmesi
                name: "PozisyonDegisikligi",
                url: "PozisyonDegisikligi",
                defaults: new { controller = "PozisyonDegisikligi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // UrunKaydi/Index sayfamızın yönlendirmesi
                name: "UrunKaydi",
                url: "UrunKaydi",
                defaults: new { controller = "UrunKaydi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // cihazTuruGetir fonksiyonunun yönlendirmesi
             name: "cihazTuruGetir",
             url: "cihazTuruGetir",
             defaults: new { controller = "UrunKaydi", action = "cihazTuruGetir", id = UrlParameter.Optional }
             );
            routes.MapRoute( // KullaniciIslemleri/Index sayfamızın yönlendirmesi
                name: "KullaniciIslemleri",
                url: "KullaniciIslemleri",
                defaults: new { controller = "KullaniciIslemleri", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // KargoTakibi/Index sayfamızın yönlendirmesi
                name: "KargoTakibi",
                url: "KargoTakibi",
                defaults: new { controller = "KargoTakibi", action = "Index", id = UrlParameter.Optional }
                );
        
            routes.MapRoute( // KullaniciyaUrunAtama/Index sayfamızın yönlendirmesi
                name: "KullaniciyaUrunAtama",
                url: "KullaniciyaUrunAtama",
                defaults: new { controller = "KullaniciyaUrunAtama", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "kayit",
                url: "KullaniciyaUrunAtama",
                defaults: new { controller = "KullaniciyaUrunAtama", action = "kayit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ArizaKayit",
                url: "ArizaBildirimi",
                defaults: new { controller = "ArizaBildirimi", action = "ArizaKayit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BagisYapKayit",
                url: "BagisYap",
                defaults: new { controller = "BagisYap", action = "BagisYapKayit", id = UrlParameter.Optional }
            );

            routes.MapRoute( // UrunKullanicisiDegistir/Index sayfamızın yönlendirmesi
                name: "UrunKullanicisiDegistir",
                url: "UrunKullanicisiDegistir",
                defaults: new { controller = "UrunKullanicisiDegistir", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute( // SistemKayitlari/Index sayfamızın yönlendirmesi
                name: "SistemKayitlari",
                url: "SistemKayitlari",
                defaults: new { controller = "SistemKayitlari", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // Cikis/Index sayfamızın yönlendirmesi
                name: "Cikis",
                url: "",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute( // PartialDepoUrunList
                name: "PartialDepoUrunList",
                url: "KullaniciyaUrunAtama/PartialDepoUrunList",
                defaults: new { controller = "PartialDepoUrunList", action = "KullaniciyaUrunAtama"}
                );
        }
    }
}
