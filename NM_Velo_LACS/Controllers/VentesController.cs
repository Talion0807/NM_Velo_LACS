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
    public class VentesController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Ventes
        [Authorize]
        public ActionResult Index()
        {
            var vente = db.Vente.Include(v => v.Client).Include(v => v.Velo);
            return View(vente.ToList());
        }

        // GET: Ventes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vente vente = db.Vente.Find(id);
            if (vente == null)
            {
                return HttpNotFound();
            }
            return View(vente);
        }

        // GET: Ventes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom");
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque");
            return View();
        }

        // POST: Ventes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDVente,Date_vente,Prix_vente,IDClient,IDVelo")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                db.Vente.Add(vente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom", vente.IDClient);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", vente.IDVelo);
            return View(vente);
        }

        // GET: Ventes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vente vente = db.Vente.Find(id);
            if (vente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom", vente.IDClient);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", vente.IDVelo);
            return View(vente);
        }

        // POST: Ventes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDVente,Date_vente,Prix_vente,IDClient,IDVelo")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClient = new SelectList(db.Client, "IDClient", "Nom", vente.IDClient);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", vente.IDVelo);
            return View(vente);
        }

        // GET: Ventes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vente vente = db.Vente.Find(id);
            if (vente == null)
            {
                return HttpNotFound();
            }
            return View(vente);
        }

        // POST: Ventes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Vente vente = db.Vente.Find(id);
            db.Vente.Remove(vente);
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
