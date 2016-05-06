using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using foursquare.Models;

namespace foursquare.Controllers
{
    public class WelcomeController : Controller
    {
        foursquareconfEntities database = new foursquareconfEntities();
        // GET: Login
        public ActionResult Index()
        {
            //HomeModel welcome = new HomeModel();
            //return View(new HomeModel() { Welcome = welcome });
            return View(new HomeModel());
        }

        public ActionResult Bio(int id)
        {
            HomeModel tm = new HomeModel();
            tm.loadmember(id);

            return View(tm);
        }
    }
}