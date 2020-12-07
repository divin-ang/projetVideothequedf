namespace projetVideothequedf.Migrations
{    
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using projetVideothequedf.Models;
    
    internal sealed class Configuration : DbMigrationsConfiguration<projetVideothequedf.DAL.VideothequeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "projetVideothequedf.DAL.VideothequeContext";
        }

        protected override void Seed(projetVideothequedf.DAL.VideothequeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.acteurs.AddOrUpdate(
                a => a.id,
                new Acteur() { nom = "Sheldon", prenom = "Cooper", iconURL= "~/photos/cooper.png" },
                 new Acteur() { nom = "Louis", prenom = "De funes", iconURL = "~/photos/louis.png" },
                  new Acteur() {  nom = "Chan", prenom = "Jackie", iconURL = "~/photos/chan.png" },
                   new Acteur() { nom = "Dujardin", prenom = "Jean", iconURL = "~/photos/reno.png" },
                    new Acteur() { nom = "Angelina", prenom = "jolie", iconURL = "~/photos/jolie.png" },
                     new Acteur() { nom = "Eddy", prenom = "Murphy", iconURL = "~/photos/eddy.png" },
                      new Acteur() { nom = "Deneuve", prenom = "Cathérine", iconURL = "~/photos/catherine.png" },
                       new Acteur() { nom = "Bekhti", prenom = "Leïla", iconURL = "~/photos/leila.png" },
                       new Acteur() { nom = "Paris", prenom = "Vanessa", iconURL = "~/photos/vanessa.png" }








                );
            context.Clients.AddOrUpdate(
               a => a.id,
               
               new Client() {addresse=" 13 rue lavoisier",email="a@gm.fr",nom="ALAIN",prenom="janvier",telephone="06786546753",},
               new Client() { addresse = " 17 rue junio", email = "a@gm.fr", nom = "André", prenom = "Sam", telephone = "06786546753", },
               new Client() { addresse = " 19 rue parierr", email = "a@gm.fr", nom = "Bron", prenom = "Olivier", telephone = "06786546753", },
               new Client() { addresse = " 13 rue lavoisier", email = "a@gm.fr", nom = "Angapay", prenom = "divin", telephone = "06786546753", },
               new Client() { addresse = "  8 rue BUCHI", email = "a@gm.fr", nom = "Faustin", prenom = "Emile", telephone = "06786546753", },
               new Client() { addresse = " 1 rue MOTORS", email = "a@gm.fr", nom = "André", prenom = "solange", telephone = "06786546753", }














               );
            context.Prets.AddOrUpdate(
               a => a.id,

               new Pret() {  cout = 19 },
                new Pret() {  cout = 45 },
                 new Pret() {  cout = 19 },
                  new Pret() {  cout = 67 },
                   new Pret() {  cout = 19 },
                    new Pret() {  cout = 19 },
                     new Pret() {  cout = 19 },
                      new Pret() { cout = 19 },
                       new Pret() { cout = 19 },
                        new Pret() {  cout = 19 }






               );

            context.DetailsPrets.AddOrUpdate(
               a => a.id,

               new DetailPret { dateDebut = new DateTime(2020,12,01),dateFin= new DateTime(2020, 12, 14),prix=46,Retour=false },
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 14), prix = 46,Retour=false },
               new DetailPret { dateDebut = new DateTime(2020, 10, 01), dateFin = new DateTime(2020, 11, 14), prix = 31,Retour=true },
               new DetailPret { dateDebut = new DateTime(2020, 12, 17), dateFin = new DateTime(2020, 12, 30), prix = 53, Retour=false},
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 14), prix = 10,Retour =true},
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 14), prix = 46,Retour=false },
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 15), prix = 46,Retour=false},
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 14), prix = 46 ,Retour=true},
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 14), prix = 46,Retour=true},
               new DetailPret { dateDebut = new DateTime(2020, 12, 01), dateFin = new DateTime(2020, 12, 14), prix = 46,Retour=false}
















               );



            context.DVDs.AddOrUpdate(
             a => a.id,
             new DVD { disponible=true},
              new DVD { disponible = true },
               new DVD { disponible = false},
                new DVD { disponible = false, },
                 new DVD { disponible = false },
                  new DVD { disponible = false },
                   new DVD { disponible = true },
                    new DVD { disponible = true },
                     new DVD { disponible = true },
                      new DVD { disponible = true, }



             );
           ;
            context.Films.AddOrUpdate(
           a => a.id,
           new Films { Acteur_id=2,Genre="Comedy",titre="Fantomas",note=8,price=12,year=1966,duree=100,icon= "~/photos/fantomas.png" } ,         new Films { Acteur_id = 6, Genre = "Comedy", titre = "Un prince à new york", note = 8, price = 12, year = 1996, duree = 120,icon= "~/photos/prince.png"},
           new Films { Acteur_id = 3, Genre="Action", titre = "Le temple de shaolin", note = 7, price = 12, year = 1999, duree = 100,icon= "~/photos/shaolin.png" },
          new Films { Acteur_id = 4, Genre="Comedy-Action", titre = "os 117 ", note = 8, price = 12, year = 1996, duree = 100,icon= "~/photos/oss.png" },
           new Films { Acteur_id = 9, Genre="Sci-Fi", titre = "Sherlock", note = 8, price = 12, year = 2018, duree = 100,icon= "~/photos/sherlock.png"},
           new Films { Acteur_id = 8, Genre="Romance", titre = "Coupable", note = 8, price = 12, year = 2014, duree = 100,icon= "~/photos/coupable.png" },
           new Films { Acteur_id = 1, Genre="History", titre = "Intouchable", note = 8, price = 12, year = 19, duree = 100,icon= "~/photos/intouchable.png"}



           );

        }
    }
}
