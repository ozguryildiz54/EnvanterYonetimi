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
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
        //    );
        //}
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Login",
                url: "",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Main",
                url: "Main",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "ArizaBildirimi",
                url: "ArizaBildirimi",
                defaults: new { controller = "ArizaBildirimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "ModelYonetimi",
                url: "ModelYonetimi",
                defaults: new { controller = "ModelYonetimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "LokasyonYonetimi",
                url: "LokasyonYonetimi",
                defaults: new { controller = "LokasyonYonetimi", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute(
                name: "OperatorAyarlari",
                url: "OperatorAyarlari",
                defaults: new { controller = "OperatorAyarlari", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "SirketYonetimi",
                url: "SirketYonetimi",
                defaults: new { controller = "SirketYonetimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "CihazTuruYonetimi",
                url: "CihazTuruYonetimi",
                defaults: new { controller = "CihazTuruYonetimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "AmortismanBildirimi",
                url: "AmortismanBildirimi",
                defaults: new { controller = "AmortismanBildirimi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "BagisYap",
                url: "BagisYap",
                defaults: new { controller = "BagisYap", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "DepoKaydi",
                url: "DepoKaydi",
                defaults: new { controller = "DepoKaydi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "IstenCikma",
                url: "IstenCikma",
                defaults: new { controller = "IstenCikma", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute(
                name: "PozisyonDegisikligi",
                url: "PozisyonDegisikligi",
                defaults: new { controller = "PozisyonDegisikligi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "UrunKaydi",
                url: "UrunKaydi",
                defaults: new { controller = "UrunKaydi", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "KullaniciIslemleri",
                url: "KullaniciIslemleri",
                defaults: new { controller = "KullaniciIslemleri", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "KargoTakibi",
                url: "KargoTakibi",
                defaults: new { controller = "KargoTakibi", action = "Index", id = UrlParameter.Optional }
                );
        
            routes.MapRoute(
                name: "KullaniciyaUrunAtama",
                url: "KullaniciyaUrunAtama",
                defaults: new { controller = "KullaniciyaUrunAtama", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "UrunKullanicisiDegistir",
                url: "UrunKullanicisiDegistir",
                defaults: new { controller = "UrunKullanicisiDegistir", action = "Index", id = UrlParameter.Optional }
                 );
            routes.MapRoute(
                name: "SistemKayitlari",
                url: "SistemKayitlari",
                defaults: new { controller = "SistemKayitlari", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Cikis",
                url: "Cikis",
                defaults: new { controller = "Cikis", action = "Index", id = UrlParameter.Optional }
                );

        }
    }
}
