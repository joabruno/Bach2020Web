using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BachelorsProjectWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindOffice(string Search)
        {
            ViewBag.searchid = Search;
            return View("FindOffice");
        }

        public ActionResult Papers( string id)
        {
            ViewBag.papers = id;
            return View();
        }


        public ActionResult Navigation(int id)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.NavDestination = id;
            return View("Navigation");
        }
    }
}