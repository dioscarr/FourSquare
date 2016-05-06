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
    public class ModeratorsController : Controller
    {
        private foursquareconfEntities db = new foursquareconfEntities();

        // GET: CMS/Moderators
        public ActionResult Index()
        {
            return View(db.Moderators.ToList());
        }

        // GET: CMS/Moderators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderators moderators = db.Moderators.Find(id);
            if (moderators == null)
            {
                return HttpNotFound();
            }
            return View(moderators);
        }

        // GET: CMS/Moderators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Moderators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Name,Title,Picture,BioName,BioTitle,Bio,Created,Modified,isDeleted")] Moderators moderators)
        {
            if (ModelState.IsValid)
            {
                db.Moderators.Add(moderators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moderators);
        }

        // GET: CMS/Moderators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderators moderators = db.Moderators.Find(id);
            if (moderators == null)
            {
                return HttpNotFound();
            }
            return View(moderators);
        }

        // POST: CMS/Moderators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Name,Title,Picture,BioName,BioTitle,Bio,Created,Modified,isDeleted")] Moderators moderators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moderators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moderators);
        }

        // GET: CMS/Moderators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderators moderators = db.Moderators.Find(id);
            if (moderators == null)
            {
                return HttpNotFound();
            }
            return View(moderators);
        }

        // POST: CMS/Moderators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moderators moderators = db.Moderators.Find(id);
            db.Moderators.Remove(moderators);
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
