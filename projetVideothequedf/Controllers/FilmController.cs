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
    public class FilmController : Controller
    {
        private VideothequeContext db = new VideothequeContext();

        // GET: Film
        public async Task<ActionResult> Index()
        {
            return View(await db.Films.ToListAsync());
        }

        // GET: Film/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Films films = await db.Films.FindAsync(id);
            if (films == null)
            {
                return HttpNotFound();
            }
            return View(films);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,duree,year,note,titre,Acteur_id,price,icon,Genre")] Films films)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(films);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(films);
        }

        // GET: Film/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Films films = await db.Films.FindAsync(id);
            if (films == null)
            {
                return HttpNotFound();
            }
            return View(films);
        }

        // POST: Film/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,duree,year,note,titre,Acteur_id,price,icon,Genre")] Films films)
        {
            if (ModelState.IsValid)
            {
                db.Entry(films).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(films);
        }

        // GET: Film/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Films films = await db.Films.FindAsync(id);
            if (films == null)
            {
                return HttpNotFound();
            }
            return View(films);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Films films = await db.Films.FindAsync(id);
            db.Films.Remove(films);
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
