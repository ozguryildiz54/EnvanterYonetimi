using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterYonetimi.Models.Entity
{
    public class cihazModel
    {
        public IEnumerable<CihazTuru> CihazTuruId { get; set; }
        public IEnumerable<Modeller> modelId { get; set; }
    }
}