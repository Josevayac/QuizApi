using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Propietarios()
        {
            ViewBag.Title = "Owners Page";
            return View();
        }

        public ActionResult Mascotas()
        {
            ViewBag.Title = "Pets Page";
            return View();
        }
    }
}