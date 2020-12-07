using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class UtilisateurVueModel                    
    {
        public UtilisateurVueModel()
        {

        }
        public int id { get; set; }
      
        public bool Authentifie { get; set; }
    }
}