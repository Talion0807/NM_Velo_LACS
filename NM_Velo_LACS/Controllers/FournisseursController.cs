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
    public class FournisseursController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Fournisseurs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Fournisseur.ToList());
        }

        // GET: Fournisseurs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = db.Fournisseur.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // GET: Fournisseurs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDFournisseur,Nom_Fournisseur,GSM,Adresse_Email,Adresse,Code_Postal")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Fournisseur.Add(fournisseur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fournisseur);
        }

        // GET: Fournisseurs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = db.Fournisseur.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDFournisseur,Nom_Fournisseur,GSM,Adresse_Email,Adresse,Code_Postal")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fournisseur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fournisseur);
        }

        // GET: Fournisseurs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = db.Fournisseur.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Fournisseur fournisseur = db.Fournisseur.Find(id);
            db.Fournisseur.Remove(fournisseur);
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
