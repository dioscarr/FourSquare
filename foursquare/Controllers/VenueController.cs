using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using foursquare.Models;

namespace foursquare.Controllers
{
    public class VenueController : Controller
    {
       
        // GET: Venue
        public ActionResult Index()
        {   HomeModel homemodel = new HomeModel();           
                return View(homemodel);
        }
    }
}