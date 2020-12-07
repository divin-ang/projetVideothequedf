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
    public class DetailPretontroller : Controller
    {
        private VideothequeContext db = new VideothequeContext();

        // GET: DetailPretontroller
        public async Task<ActionResult> Index()
        {
            return View(await db.DetailsPrets.ToListAsync());
        }

        // GET: DetailPretontroller/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailPret detailPret = await db.DetailsPrets.FindAsync(id);
            if (detailPret == null)
            {
                return HttpNotFound();
            }
            return View(detailPret);
        }

        // GET: DetailPretontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailPretontroller/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,prix,Retour,dateDebut,DVD_id,Pret_id,dateFin")] DetailPret detailPret)
        {
            if (ModelState.IsValid)
            {
                db.DetailsPrets.Add(detailPret);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(detailPret);
        }

        // GET: DetailPretontroller/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailPret detailPret = await db.DetailsPrets.FindAsync(id);
            if (detailPret == null)
            {
                return HttpNotFound();
            }
            return View(detailPret);
        }

        // POST: DetailPretontroller/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,prix,Retour,dateDebut,DVD_id,Pret_id,dateFin")] DetailPret detailPret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailPret).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detailPret);
        }

        // GET: DetailPretontroller/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailPret detailPret = await db.DetailsPrets.FindAsync(id);
            if (detailPret == null)
            {
                return HttpNotFound();
            }
            return View(detailPret);
        }

        // POST: DetailPretontroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DetailPret detailPret = await db.DetailsPrets.FindAsync(id);
            db.DetailsPrets.Remove(detailPret);
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
