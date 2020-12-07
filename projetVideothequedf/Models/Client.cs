using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class Client
    {
        public Client()
        {
            this.Prets = new HashSet<Pret>();
        }

       
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        [Required (ErrorMessage = "Le prénom est réquis")]
        public string prenom { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Le nom est réquis")]
        public string nom { get; set; }
        [MaxLength(150)]
        [Required]
        public string addresse { get; set; }
        [Required(ErrorMessage = "l'adresse est réquis")]
        [Phone]
        public string telephone { get; set; }
        [Required(ErrorMessage = "L' adresse email est réquis")]
        [EmailAddress]
        public string email { get; set; }

        public virtual ICollection<Pret> Prets { get; set; }
    }
}
