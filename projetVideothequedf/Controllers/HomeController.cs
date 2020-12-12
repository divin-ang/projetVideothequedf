using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projetVideothequedf.DAL;
using PagedList;

namespace projetVideothequedf.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        VideothequeContext db = new VideothequeContext();
     
        public ActionResult Index(string sortOrder, string currentFilter, string SearchName,string genre,int ?year,int?page)
        {

            if (SearchName != null)
            {
                page = 1;
            }
            else
            {
                SearchName = currentFilter;
            }
            ViewBag.CurrentFilter = SearchName;
            var movies = from m in db.Films
                         select m;
            
            if (!String.IsNullOrEmpty(SearchName))
            {
                movies = movies.Where(s => s.titre.Contains(SearchName));
              
            }
            if (!String.IsNullOrEmpty(genre))
            {
                movies = movies.Where(s => s.Genre.Contains(genre));

            }
            if (year !=null)
            {
                movies = movies.Where(s => s.year == year);


            }





            switch (sortOrder)
            {
                case "note desc":
                    movies = movies.OrderBy(x => x.exemplaires);
                    break;

                default: // Not: case "Default"
                    movies = movies.OrderBy(x => x.exemplaires);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View(movies.ToPagedList(pageNumber,pageSize));
        }
    }
}