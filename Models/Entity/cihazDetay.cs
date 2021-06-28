using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterYonetimi.Models.Entity
{
    public class cihazDetay
    {
        // Bu sınıf cihaz türü ve cihaz modeli değerlerine erişim için tanımlandı. Yani ilgili cihaz türünde ki cihaz modellerine erişim için kullanıyoruz.

        [Display(Name = "Cihaz Türü")]
        public int cihazTuruId { get; set; }

        [Display(Name = "Model Türü")]
        public int modelId { get; set; }

        public List<SelectListItem> cihazTurleri { get; set; }

        public List<SelectListItem> modeller { get; set; }

        public Depo depo { get; set; }
        public Saha saha { get; set;
        }
        public List<Depo> DepoGetir { get; set; }

        public string cihazTuruID { get; set; }
        public string cihazModeliId { get; set; }
        public string envNo { get; set; }
        public string seriNo { get; set; }
        public string garantiBas { get; set; }
        public string durum { get; set; }
        public string islemZaman { get; set; }
        public string islemiYapan { get; set; }
        public string kullanim { get; set; }
        public string aciklama { get; set; }
        public string sifirIkinciEl { get; set; }
        public string iade { get; set; }
        public string termin { get; set; }

        public int sahaId { get; set; }
        public string kullaniciAdi { get; set; }
        public string kullaniciSoyadi { get; set; }
        public string sirketId { get; set; }
        public string lokasyonId { get; set; }
        public string operatorId { get; set; }
        public string sifir_ikinci_el { get; set; }



    }
}