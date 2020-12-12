using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using projetVideothequedf.DAL;
using projetVideothequedf.Models;

namespace projetVideothequedf.Controllers
{
    public class FactureController : Controller
    {
        // GET: Facture

        private VideothequeContext db = new VideothequeContext();
        [HttpGet]
        public ActionResult pdf()
        {
            return View();
        }

        [HttpPost]
        public FileStreamResult pdf(string nom , string prenom,string titreFilm)
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            Chunk c = new Chunk(nom, FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD));
            Paragraph p = new Paragraph(c);

            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingAfter = 12;
            
            document.Add(p);
            document.Add(new Paragraph(prenom));
            document.Add(new Paragraph(titreFilm));
            document.Add(new Paragraph(DateTime.Now.ToString()));
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }


    }


    }
