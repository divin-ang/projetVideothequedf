using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetVideothequedf.Models
{
    public class Pret
    {

        public Pret()
        {
            this.DetailPret = new HashSet<DetailPret>();
        }

        public int id { get; set; }



       
       
     
        public int Clients_id { get; set; }
        

     
        public Nullable<decimal> cout { get; set; }

        public virtual Client Clients{ get; set; }
        public virtual ICollection<DetailPret> DetailPret { get; set; }
   
    }
}
