using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterYonetimi.Models.Entity
{
    public class cihazDetay
    {
        // Bu sınıf cihaz türü ve cihaz modeli değerlerine erişim için tanımlandı. Yani ilgili cihaz türünde ki cihaz modellerine erişim için kullanıyoruz.
        public int cihazTuruId { get; set; }
        public int modelId { get; set; }
        public string envNo { get; set; }
        public string seriNo { get; set; }
    }
}