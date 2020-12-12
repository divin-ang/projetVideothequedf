namespace projetVideothequedf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acteurs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prenom = c.String(),
                        nom = c.String(),
                        iconURL = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        duree = c.Int(),
                        year = c.Int(),
                        exemplaires = c.Int(nullable: false),
                        idRealisateur = c.Int(nullable: false),
                        titre = c.String(nullable: false),
                        Acteur_id = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        icon = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        disponible = c.Boolean(nullable: false),
                        Films_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Films", t => t.Films_id)
                .Index(t => t.Films_id);
            
            CreateTable(
                "dbo.DetailPrets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Retour = c.Boolean(nullable: false),
                        dateDebut = c.DateTime(nullable: false),
                        idClient = c.Int(nullable: false),
                        dateFin = c.DateTime(),
                        idFilm = c.Int(nullable: false),
                        Pret_id = c.Int(),
                        client_id = c.Int(),
                        vFilms_id = c.Int(),
                        DVD_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Prets", t => t.Pret_id)
                .ForeignKey("dbo.Clients", t => t.client_id)
                .ForeignKey("dbo.Films", t => t.vFilms_id)
                .ForeignKey("dbo.DVDs", t => t.DVD_id)
                .Index(t => t.Pret_id)
                .Index(t => t.client_id)
                .Index(t => t.vFilms_id)
                .Index(t => t.DVD_id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prenom = c.String(nullable: false, maxLength: 50),
                        nom = c.String(nullable: false, maxLength: 50),
                        addresse = c.String(nullable: false, maxLength: 150),
                        telephone = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Clients_id = c.Int(nullable: false),
                        cout = c.Decimal(precision: 18, scale: 2),
                        Clients_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.Clients_id1)
                .Index(t => t.Clients_id1);
            
            CreateTable(
                "dbo.Realisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        prenom = c.String(nullable: false, maxLength: 50),
                        nom = c.String(nullable: false, maxLength: 50),
                        iconURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmsActeurs",
                c => new
                    {
                        Films_id = c.Int(nullable: false),
                        Acteur_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Films_id, t.Acteur_id })
                .ForeignKey("dbo.Films", t => t.Films_id)
                .ForeignKey("dbo.Acteurs", t => t.Acteur_id)
                .Index(t => t.Films_id)
                .Index(t => t.Acteur_id);
            
            CreateTable(
                "dbo.RealisateurFilms",
                c => new
                    {
                        Realisateur_Id = c.Int(nullable: false),
                        Films_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Realisateur_Id, t.Films_id })
                .ForeignKey("dbo.Realisateurs", t => t.Realisateur_Id)
                .ForeignKey("dbo.Films", t => t.Films_id)
                .Index(t => t.Realisateur_Id)
                .Index(t => t.Films_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RealisateurFilms", "Films_id", "dbo.Films");
            DropForeignKey("dbo.RealisateurFilms", "Realisateur_Id", "dbo.Realisateurs");
            DropForeignKey("dbo.DVDs", "Films_id", "dbo.Films");
            DropForeignKey("dbo.DetailPrets", "DVD_id", "dbo.DVDs");
            DropForeignKey("dbo.DetailPrets", "vFilms_id", "dbo.Films");
            DropForeignKey("dbo.DetailPrets", "client_id", "dbo.Clients");
            DropForeignKey("dbo.DetailPrets", "Pret_id", "dbo.Prets");
            DropForeignKey("dbo.Prets", "Clients_id1", "dbo.Clients");
            DropForeignKey("dbo.FilmsActeurs", "Acteur_id", "dbo.Acteurs");
            DropForeignKey("dbo.FilmsActeurs", "Films_id", "dbo.Films");
            DropIndex("dbo.RealisateurFilms", new[] { "Films_id" });
            DropIndex("dbo.RealisateurFilms", new[] { "Realisateur_Id" });
            DropIndex("dbo.FilmsActeurs", new[] { "Acteur_id" });
            DropIndex("dbo.FilmsActeurs", new[] { "Films_id" });
            DropIndex("dbo.Prets", new[] { "Clients_id1" });
            DropIndex("dbo.DetailPrets", new[] { "DVD_id" });
            DropIndex("dbo.DetailPrets", new[] { "vFilms_id" });
            DropIndex("dbo.DetailPrets", new[] { "client_id" });
            DropIndex("dbo.DetailPrets", new[] { "Pret_id" });
            DropIndex("dbo.DVDs", new[] { "Films_id" });
            DropTable("dbo.RealisateurFilms");
            DropTable("dbo.FilmsActeurs");
            DropTable("dbo.Realisateurs");
            DropTable("dbo.Prets");
            DropTable("dbo.Clients");
            DropTable("dbo.DetailPrets");
            DropTable("dbo.DVDs");
            DropTable("dbo.Films");
            DropTable("dbo.Acteurs");
        }
    }
}
