using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace projetVideothequedf.Models
{
    public class DetailPret
    {



        [Key]
        public int id { get; set; }
       

        [Required(ErrorMessage = "Veuillez renseigner le prix")]
        public decimal prix { get; set; }
        [Required(ErrorMessage = "Veuillez renseigner la date de retour")]
        public bool Retour { get; set; }
        [Required(ErrorMessage = " veuillez renseigner la date de début")]
        public DateTime dateDebut { get; set; }

      
        public   int idClient { get; set; }
        public Nullable<DateTime> dateFin { get; set; }
        public int idFilm { get; set; }

        public virtual Client client { get; set; }

        public virtual Films vFilms { get; set; }
        
    }
}