using System;
using System.Collections.Generic;
using System.Linq;
using System.Web ;
using projetVideothequedf.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace projetVideothequedf.DAL
{
    public class VideothequeContext: DbContext
    {

        public VideothequeContext() : base("VideothequeContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        
        public DbSet<Acteur>acteurs{ get; set; }
        public DbSet<Pret> Prets { get; set; }


        public DbSet<DetailPret> DetailsPrets { get; set; }
        public DbSet<DVD> DVDs { get; set; }
        
        public DbSet<Realisateur> Realisateurs { get; set; }
        public DbSet<Films> Films { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();






        }




    }
}