using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterYonetimi.Models.Entity
{
    public class modelData
    {
        envanterTakipWebEntities2 db = new envanterTakipWebEntities2();
        public List<Depo> getDepo()
        {
            return db.Depo.ToList();
        }
        public List<CihazTuru> getCihazTurleri()
        {
            return db.CihazTuru.ToList();
        }
        public List<Modeller> getModels()
        {
            return db.Modeller.ToList();
        }
    }
}