using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Evento()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Speakers()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AspNetLandPage()
        {

            return View();
        }
    }
}