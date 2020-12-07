using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;                                                       
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class Films
    {
        public int id { get; set; }
        
        public Nullable<int> duree { get; set; }

        public Nullable<int> year { get; set; }

        public Nullable<int> note { get; set; }


        [Required(ErrorMessage = " Veuillez renseigner le titre du film")]
        public string titre { get; set; }
        public int Acteur_id { get; set; }






        public virtual ICollection<DVD> DVD { get; set; }
        public virtual ICollection<Acteur> Acteurs { get; set; }
        
        public virtual ICollection<Realisateur> Realisateurs { get; set; }


     

        [Required]
        public int price { get; set; }
        public string icon { get; set; }
        public string Genre { get; set; }





    }
}
