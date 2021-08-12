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
        public ActionResult Index()
        {
            return View();
        }
    }
}