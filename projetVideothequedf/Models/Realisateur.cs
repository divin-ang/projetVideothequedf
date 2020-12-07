using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class Realisateur
    {
        public Realisateur()
        {
            this.Films = new HashSet<Films>();         
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string prenom { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom { get; set; }
        public string iconURL { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}