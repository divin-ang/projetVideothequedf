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
    public class ClientController : Controller
    {
        private VideothequeContext db = new VideothequeContext();

        // GET: Client
        public async Task<ActionResult> Index()
        {
            return View(await db.Clients.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,prenom,nom,addresse,telephone,email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Preter","DetailPret");
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,prenom,nom,addresse,telephone,email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Emprunteurs(string f)
        {

            if (f == null)
            {
                f = "";
            }
            var query =
             (from c in db.Clients
              join detailPret in db.DetailsPrets on c.id equals detailPret.idClient
              join film in db.Films on detailPret.idFilm equals film.id
              select new
              {
                  nom = c.nom,
                  prenom = c.prenom,
                  adresse = c.addresse,
                  email = c.email,
                  telephone = c.telephone,
                  titre = film.titre,
                  icon = film.icon,
                  dateDebut = detailPret.dateDebut,
                  dateFin = detailPret.dateFin
              }).ToList()
               .Select(film => new ClientLocation
               {
                   nom = film.nom,
                   prenom = film.prenom,
                   addresse = film.adresse,
                   email = film.email,
                   telephone = film.telephone,
                   titre = film.titre,
                   icon = film.icon,
                   dateDebut = film.dateDebut,
                   dateFin = film.dateFin
               }).Where(x => x.titre.Contains(f));

            ViewBag.films = new SelectList(db.Films, "titre", "titre", "year");
            ViewBag.Model = query;
            return View(query.ToList());

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
