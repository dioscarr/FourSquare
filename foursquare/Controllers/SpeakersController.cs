using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using foursquare.Models;

namespace foursquare.Controllers
{
    public class SpeakersController : Controller
    {
        foursquareconfEntities database = new foursquareconfEntities();
        // GET: Speakers

        public ActionResult Index(int? id, string archive, string Close)
        {
            ViewBag.Close = Close;
            if (id != null)
            {
                ViewBag.Close = "true";
                ViewBag.Archive = archive;
                ViewBag.CurrentYear = id;
                ViewBag.Active = "";
                ViewBag.Active = "activeNav";
                HomeModel NM = new HomeModel((int)id);
                if (archive == "archive")
                {
                    //NM.loadArchive();
                    NM.loadArchive((int)id);
                }

                return View(NM);
            }
            else if (archive == "archive" && ViewBag.Close != "true")
            {
                ViewBag.Close = "true";
                ViewBag.Archive = archive;
                ViewBag.Active = "activeNav";
                HomeModel NM = new HomeModel();
                NM.loadArchive();
                return View(NM);
            }
            else if (ViewBag.Close == "true")
            {
                ViewBag.Active = "";
                ViewBag.Archive = "";
                ViewBag.Close = "";
                HomeModel NM2 = new HomeModel();
                return View(NM2);
            }
            ViewBag.Active = "";
            HomeModel NM1 = new HomeModel();
            return View(NM1);
        }

        //public ActionResult Index()
        //{
        //    return View( new HomeModel() );
        //}
    }
}