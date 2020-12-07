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
    public class DVDsController : Controller
    {
        private VideothequeContext db = new VideothequeContext();

        // GET: DVDs
        public async Task<ActionResult> Index()
        {
            return View(await db.DVDs.ToListAsync());
        }

        // GET: DVDs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVD dVD = await db.DVDs.FindAsync(id);
            if (dVD == null)
            {
                return HttpNotFound();
            }
            return View(dVD);
        }

        // GET: DVDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVDs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Films_id,disponible")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                db.DVDs.Add(dVD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dVD);
        }

        // GET: DVDs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVD dVD = await db.DVDs.FindAsync(id);
            if (dVD == null)
            {
                return HttpNotFound();
            }
            return View(dVD);
        }

        // POST: DVDs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Films_id,disponible")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dVD);
        }

        // GET: DVDs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVD dVD = await db.DVDs.FindAsync(id);
            if (dVD == null)
            {
                return HttpNotFound();
            }
            return View(dVD);
        }

        // POST: DVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DVD dVD = await db.DVDs.FindAsync(id);
            db.DVDs.Remove(dVD);
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
