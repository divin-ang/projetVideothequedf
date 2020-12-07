using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class Acteur
    {
        public Acteur()
        {
            this.Films = new HashSet<Films>();
        }


        public int id { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string iconURL { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}
