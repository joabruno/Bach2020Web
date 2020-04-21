using BachelorsProjectWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BachelorsProjectWebApp.Controllers
{
    
    public class HomeController : Controller
    {
        DBMapper dbmapper = new DBMapper();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditPlan()
        {
            return View();
        }

        public ActionResult NavigationDemo(int id)
        {
            ViewBag.demo_id = id;
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