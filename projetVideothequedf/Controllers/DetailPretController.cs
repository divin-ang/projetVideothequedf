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


using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PagedList;

namespace projetVideothequedf.Controllers
{
    public class DetailPretController : Controller
    {
        private VideothequeContext db = new VideothequeContext();
       
        public ActionResult EnLocation()
        {
    

            var query =
              ( from film in db.Films
                join detail in db.DetailsPrets
                    on film.id equals detail.idFilm
                where detail.Retour == false
                select  new  {Genre=film.Genre, exemplaires=film.exemplaires,duree=film.duree, icon=film.icon,price=film.price,titre=film.titre,year=film.year,Acteurs=film.Acteurs,Acteur_id=film.Acteur_id,DVD=film.DVD,id=film.id,idRealisateur
                =film.idRealisateur,Realisateurs=film.Realisateurs,dateDebut=detail.dateDebut,dateFin =detail.dateFin}).ToList()
                .Select(film=>new FilmRetour {dateDebut=film.dateDebut,dateFin=film.dateFin ,Genre = film.Genre ,exemplaires = film.exemplaires, duree = film.duree, icon = film.icon, price = film.price, titre = film.titre, year = film.year, Acteurs = film.Acteurs, Acteur_id = film.Acteur_id, DVD = film.DVD, id = film.id, idRealisateur=film.idRealisateur,Realisateurs=film.Realisateurs });

            
               


            return View(query.ToList());


        }
        [HttpGet]
        public ActionResult Preter()
        {
            ViewBag.client = new SelectList(db.Clients, "id", "prenom", "email");
            ViewBag.Films = new SelectList(db.Films, "id", "titre");
            return View();
        }

        [HttpPost]
        public FileStreamResult Preter(int ?client,int ?film)
        {
          
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            
           
           
           

            IQueryable<Client> clientQuery =
            from cust in db.Clients
            where cust.id == client
            select cust;
            string nom = "";
            foreach (Client num in clientQuery)
            {
                nom = "Facturé à "+num.nom+" "+num.prenom+"\n"+num.addresse+"\n"+num.telephone+"\n"+num.email;

            }

            IQueryable<Films> filmQuery =
            from element in db.Films
            where element.id == film
            select element;
            string titre = "";
            string genre = "";
            int duree = 0;
            DateTime date = new DateTime();
            int prix = 0;
            foreach (Films num in filmQuery)
            {
                titre = num.titre;
                genre = num.Genre;
                duree = (int)num.duree;
                prix = num.price;

            }

            string detail = "Titre : " + titre + "\nGenre : " + genre + "\nDurée : " + duree / 60 + "h: " + duree % 60;
            Chunk d = new Chunk("FilmManager", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD,Color.ORANGE));
            Paragraph p1= new Paragraph(d);
            p1.Alignment = Element.ALIGN_LEFT;
            p1.SpacingAfter = 12;

            document.Add(p1);

            Chunk c = new Chunk(nom, FontFactory.GetFont(FontFactory.COURIER, 12));
            Paragraph p = new Paragraph(c);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 12;

            document.Add(p);

            PdfPTable table = new PdfPTable(3);
            table.AddCell("Quantité");
            table.AddCell("Detail du produit");
            table.AddCell("Montant");
            table.AddCell("1");
            table.AddCell(detail);
            table.AddCell(prix+" euros");
            document.Add(table);

           
            
            document.Add(new Paragraph(DateTime.Now.ToString()));
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");

           
        } 

        // GET: DetailPret
        public async Task<ActionResult> Index()
        {
            return View(await db.DetailsPrets.ToListAsync());
        }

        // GET: DetailPret/Details/5
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

        // GET: DetailPret/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailPret/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,prix,Retour,dateDebut,dateFin")] DetailPret detailPret)
        {
            if (ModelState.IsValid)
            {
                db.DetailsPrets.Add(detailPret);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(detailPret);
        }

        // GET: DetailPret/Edit/5
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

        // POST: DetailPret/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,prix,Retour,dateDebut,dateFin")] DetailPret detailPret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailPret).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(detailPret);
        }

        // GET: DetailPret/Delete/5
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

        // POST: DetailPret/Delete/5
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
