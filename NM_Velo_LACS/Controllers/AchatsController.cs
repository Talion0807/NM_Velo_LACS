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
    public class AchatsController : Controller
    {
       

        private BddContext db = new BddContext();

        // GET: Achats
        [Authorize]
        public ActionResult Index()
        {
            var achat = db.Achat.Include(a => a.Fournisseur).Include(a => a.Velo);
            return View(achat.ToList());
        }

        // GET: Achats/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achat achat = db.Achat.Find(id);
            if (achat == null)
            {
                return HttpNotFound();
            }
            return View(achat);
        }

        // GET: Achats/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDFournisseur = new SelectList(db.Fournisseur, "IDFournisseur", "Nom_Fournisseur");
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque");
            return View();
        }

        // POST: Achats/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDAchat,Date_Achat,Prix,IDVelo,IDFournisseur")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                db.Achat.Add(achat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFournisseur = new SelectList(db.Fournisseur, "IDFournisseur", "Nom_Fournisseur", achat.IDFournisseur);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", achat.IDVelo);
            return View(achat);
        }

        // GET: Achats/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achat achat = db.Achat.Find(id);
            if (achat == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFournisseur = new SelectList(db.Fournisseur, "IDFournisseur", "Nom_Fournisseur", achat.IDFournisseur);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", achat.IDVelo);
            return View(achat);
        }

        // POST: Achats/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDAchat,Date_Achat,Prix,IDVelo,IDFournisseur")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFournisseur = new SelectList(db.Fournisseur, "IDFournisseur", "Nom_Fournisseur", achat.IDFournisseur);
            ViewBag.IDVelo = new SelectList(db.Velo, "IDVelo", "Marque", achat.IDVelo);
            return View(achat);
        }

        // GET: Achats/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achat achat = db.Achat.Find(id);
            if (achat == null)
            {
                return HttpNotFound();
            }
            return View(achat);
        }

        // POST: Achats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Achat achat = db.Achat.Find(id);
            db.Achat.Remove(achat);
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
