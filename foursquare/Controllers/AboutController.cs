using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using foursquare.Models;

namespace foursquare.Controllers
{
    public class AboutController : Controller
    {
        foursquareconfEntities database = new foursquareconfEntities();
        // GET: About
        public ActionResult Index()
        {
            return View(new HomeModel());
        }
    }
}