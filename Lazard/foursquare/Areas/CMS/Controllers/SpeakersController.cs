using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using foursquare.Models;

namespace foursquare.Areas.CMS.Controllers
{
    public class SpeakersController : Controller
    {
        private foursquareconfEntities db = new foursquareconfEntities();

        // GET: CMS/Speakers
        public ActionResult Index()
        {
            return View(db.Speakers.ToList());
        }

        // GET: CMS/Speakers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speakers speakers = db.Speakers.Find(id);
            if (speakers == null)
            {
                return HttpNotFound();
            }
            return View(speakers);
        }

        // GET: CMS/Speakers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Speakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Name,Title,Picture,BioName,BioTitle,Bio,Created,Modified,isDeleted")] Speakers speakers)
        {
            if (ModelState.IsValid)
            {
                db.Speakers.Add(speakers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speakers);
        }

        // GET: CMS/Speakers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speakers speakers = db.Speakers.Find(id);
            if (speakers == null)
            {
                return HttpNotFound();
            }
            return View(speakers);
        }

        // POST: CMS/Speakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Name,Title,Picture,BioName,BioTitle,Bio,Created,Modified,isDeleted")] Speakers speakers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speakers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speakers);
        }

        // GET: CMS/Speakers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speakers speakers = db.Speakers.Find(id);
            if (speakers == null)
            {
                return HttpNotFound();
            }
            return View(speakers);
        }

        // POST: CMS/Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speakers speakers = db.Speakers.Find(id);
            db.Speakers.Remove(speakers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
