using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
     
        
        public Nullable<DateTime> dateFin { get; set; }

        public virtual DVD DVD { get; set; }
        public virtual Pret Pret { get; set; }
    }
}
