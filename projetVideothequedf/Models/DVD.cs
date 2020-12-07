using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class DVD
    {
        public DVD()
        {
            this.DetailPrets = new HashSet<DetailPret>();
        }

        public int id { get; set; }                                     
        
       
        [Required]
        public bool disponible{ get; set; }

 
        public virtual ICollection<DetailPret> DetailPrets{ get; set; }
    }
}
