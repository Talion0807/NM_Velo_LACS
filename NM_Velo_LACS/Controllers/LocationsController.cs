using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NM_Velo_LACS.Models;

namespace NM_Velo_LACS.Controllers
{
    public class LocationsController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Locations
        [Authorize]
        public ActionResult Index()
        {
            var location = db.Location.Include(l => l.Client).Include(l => l.Velo);
            return View(location.ToList());
        }

        // GET: Locations/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom");
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque");
            return View();
        }

        // POST: Locations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDLocation,Date_Debut,Date_Fin,Prix_location,Caution,IDClient,IDVelo")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Location.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom", location.IDClient);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", location.IDVelo);
            return View(location);
        }

        // GET: Locations/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom", location.IDClient);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", location.IDVelo);
            return View(location);
        }

        // POST: Locations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDLocation,Date_Debut,Date_Fin,Prix_location,Caution,IDClient,IDVelo")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom", location.IDClient);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", location.IDVelo);
            return View(location);
        }

        // GET: Locations/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Location.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Location.Find(id);
            db.Location.Remove(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
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
