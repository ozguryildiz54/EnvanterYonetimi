using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvanterYonetimi.Models;
using EnvanterYonetimi.Models.Entity;

namespace EnvanterYonetimi.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        envanterTakipWebEntities database = new envanterTakipWebEntities(); // Database bağlantı nesnesi tanımlandı
        public ActionResult Index()
        {
            var modelsonuc = database.Modeller.ToList();
            return View(modelsonuc);
        }
    }
}