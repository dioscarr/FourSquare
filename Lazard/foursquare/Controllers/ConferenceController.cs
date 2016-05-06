using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using foursquare.Models;

namespace foursquare.Controllers
{
    public class ConferenceController : Controller
    {
        // GET: Conference
        public ActionResult Index(int id)
        {
            HomeModel CM = new HomeModel(id);

            //show active year navigation tab and year for page
            ViewBag.CurrentYear = id;

            return View(CM);
        }
        
        public ActionResult BioSpeakers(int id)
        {
            HomeModel tm = new HomeModel();
            tm.loadconfBio(id);

            return View(tm);
        }

        public ActionResult BioModerators(int id)
        {
            HomeModel tm = new HomeModel();
            tm.loadconfBioModerators(id);

            return View(tm);
        }

    }
}