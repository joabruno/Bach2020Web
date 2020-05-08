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
        public ActionResult EditPlan(int id)
        {
            var fm = dbmapper.GetFloorPlanByID(id);
            List<OfficeModel> offices = new List<OfficeModel>();
            offices = dbmapper.GetOfficesByFloorID(id);

            ViewBag.imgurl = fm.Floorplan;
            ViewBag.FloorID = id;
            return View(offices);
        }

        [HttpPost]
        public ActionResult EditPlan(BeaconModel bm)
        {
            var beacons = new List<BeaconModel>();
            var tracks = new List<BeaconModel>();
            
            string[] seperator = { " " };
            string[] posSeperator = { "," };


            try
            {
                string[] beaconIdList = bm.beaconIDString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                string[] beaconPosList = bm.beaconPosString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                string[] officeids = bm.OfficeIDString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                string[] trackPosList = bm.trackPosString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < beaconPosList.Length; i++)
                {
                    string[] xyPos = beaconPosList[i].Split(posSeperator, StringSplitOptions.RemoveEmptyEntries);
                    float floatx = float.Parse(xyPos[0]);
                    float floaty = float.Parse(xyPos[1]);
                    beacons.Add(new BeaconModel { OfficeID = int.Parse(officeids[i]), beaconId = beaconIdList[i], xPos = floatx, yPos = floaty });
                }
                for (int i = 0; i < trackPosList.Length; i++)
                {
                    string[] xyPos = trackPosList[i].Split(posSeperator, StringSplitOptions.RemoveEmptyEntries);
                    float floatx = float.Parse(xyPos[0]);
                    float floaty = float.Parse(xyPos[1]);
                    tracks.Add(new BeaconModel { FloorID=bm.FloorID, beaconId = beaconIdList[i], xPos = floatx, yPos = floaty });
                }

                foreach (var beacon in beacons)
                {
                    dbmapper.AddBeacon(beacon);
                }
                foreach (var track in tracks)
                {
                    dbmapper.AddTrack(track);
                }
            }
            catch (Exception)
            {

            }

            ViewBag.bString = bm.beaconPosString;

            return RedirectToAction("EditPlan", new { id = bm.FloorID });
        }

        public ActionResult NavigationDemo(string destination)
        {
            string[] seperator = { "," };
            string[] urlpars = destination.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            var nm = new NavigationModel();
            nm.beaconlist = dbmapper.GetAllBeaconsOnFloorByID(int.Parse(urlpars[1]));
            nm.tracklist = dbmapper.GetAllTracksOnFloorByID(int.Parse(urlpars[1]));

            ViewBag.demo_id = urlpars[0];
            return View(nm);
        }

        public ActionResult FindOffice(string Search)
        {
            ViewBag.searchid = Search;
            return View("FindOffice");
        }

        public ActionResult Papers(string id)
        {
            ViewBag.papers = id;
            return View();
        }


        public ActionResult UploadFloorPlan()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UploadFloorPlan(FloorModel fm)
        {
            //Something database get id when execute query
            
            var floorplanid = dbmapper.AddFloor(new FloorModel {BuildingID = 1, Floorplan=fm.Floorplan, FloorName=fm.FloorName });

            return RedirectToAction("EditPlan", new { id = floorplanid } );
        }

        public ActionResult Navigation(int id)
        {
            var intl = new List<int>();
            intl.Add(1);
            intl.Add(2);
            ViewBag.intlist = intl;
            ViewBag.Message = "Your contact page.";
            ViewBag.NavDestination = id;
            return View("Navigation");
        }
    }
}