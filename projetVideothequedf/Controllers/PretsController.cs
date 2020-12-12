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
    public class PretsController : Controller
    {
        private VideothequeContext db = new VideothequeContext();

        // GET: Prets
        public ActionResult Preter()
        {
            return View();
        }
        public async Task<ActionResult> Index()
        {
            return View(await db.Prets.ToListAsync());
        }

        // GET: Prets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = await db.Prets.FindAsync(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // GET: Prets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Clients_id,cout")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Prets.Add(pret);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pret);
        }

        // GET: Prets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = await db.Prets.FindAsync(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // POST: Prets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Clients_id,cout")] Pret pret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pret).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pret);
        }

        // GET: Prets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pret pret = await db.Prets.FindAsync(id);
            if (pret == null)
            {
                return HttpNotFound();
            }
            return View(pret);
        }

        // POST: Prets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pret pret = await db.Prets.FindAsync(id);
            db.Prets.Remove(pret);
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
