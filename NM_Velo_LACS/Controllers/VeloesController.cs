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
    public class VeloesController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Veloes
        [Authorize]
        public ActionResult Index()
        {
            var velo = db.Velo;
            return View(velo.ToList());
        }

        public  string Info()
        {
            int nbvelo = db.Velo.Count();
            return nbvelo.ToString();

        }

        public ActionResult VeloVenduCetteAnnee (int? id)
        {
            var velo = db.Velo.ToList();
            var vente = db.Vente.ToList();
            var rep = from vel in velo
                      join ven in vente on vel.IDVelo equals ven.IDVelo
                      where ven.Date_vente.Year == DateTime.Now.Year
                      select new VeloVenduAnnee { veloDetails = vel, venteDetails = ven };
            return View(rep);
        }

        // GET: Veloes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velo velo = db.Velo.Find(id);
            if (velo == null)
            {
                return HttpNotFound();
            }
            return View(velo);
        }

        // GET: Veloes/Create
        [Authorize]
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Veloes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDVelo,Marque,Pouces,Annee_achat,Couleur,Prix_location,Prix_vente,Caution,NomImage")] Velo velo)
        {
            if (ModelState.IsValid)
            {
                db.Velo.Add(velo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(velo);
        }

        // GET: Veloes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velo velo = db.Velo.Find(id);
            if (velo == null)
            {
                return HttpNotFound();
            }
            
            return View(velo);
        }

        // POST: Veloes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDVelo,Marque,Pouces,Annee_achat,Couleur,Prix_location,Prix_vente,Caution,NomImage")] Velo velo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(velo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(velo);
        }

        // GET: Veloes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velo velo = db.Velo.Find(id);
            if (velo == null)
            {
                return HttpNotFound();
            }
            return View(velo);
        }

        // POST: Veloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Velo velo = db.Velo.Find(id);
            db.Velo.Remove(velo);
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
