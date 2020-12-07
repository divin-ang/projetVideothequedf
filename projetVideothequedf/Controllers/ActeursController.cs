using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projetVideothequedf.DAL;
using projetVideothequedf.Models;

namespace projetVideothequedf.Controllers
{
    public class ActeursController : Controller
    {
        private VideothequeContext db = new VideothequeContext();

        // GET: Acteurs
        public async Task<ActionResult> Index()
        {
            return View(await db.acteurs.ToListAsync());
        }

        // GET: Acteurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acteur acteur = await db.acteurs.FindAsync(id);
            if (acteur == null)
            {
                return HttpNotFound();
            }
            return View(acteur);
        }

        // GET: Acteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acteurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,prenom,nom,iconURL")] Acteur acteur)
        {
            if (ModelState.IsValid)
            {
                db.acteurs.Add(acteur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(acteur);
        }

        // GET: Acteurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acteur acteur = await db.acteurs.FindAsync(id);
            if (acteur == null)
            {
                return HttpNotFound();
            }
            return View(acteur);
        }

        // POST: Acteurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,prenom,nom,iconURL")] Acteur acteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acteur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(acteur);
        }

        // GET: Acteurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acteur acteur = await db.acteurs.FindAsync(id);
            if (acteur == null)
            {
                return HttpNotFound();
            }
            return View(acteur);
        }

        // POST: Acteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Acteur acteur = await db.acteurs.FindAsync(id);
            db.acteurs.Remove(acteur);
            await db.SaveChangesAsync();
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
