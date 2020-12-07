namespace projetVideothequedf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailPret", "DVD_id", "dbo.DVD");
            DropForeignKey("dbo.DetailPret", "Pret_id", "dbo.Pret");
            DropIndex("dbo.DVD", new[] { "films_id" });
            DropIndex("dbo.DetailPret", new[] { "DVD_id" });
            DropIndex("dbo.DetailPret", new[] { "Pret_id" });
            AddColumn("dbo.Films", "Acteur_id", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "icon", c => c.String());
            AddColumn("dbo.Films", "Genre_id", c => c.Int(nullable: false));
            AddColumn("dbo.DetailPret", "DVD_id1", c => c.Int());
            AddColumn("dbo.DetailPret", "Pret_id1", c => c.Int());
            AlterColumn("dbo.DVD", "Films_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPret", "DVD_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPret", "Pret_id", c => c.Int(nullable: false));
            CreateIndex("dbo.DVD", "films_id");
            CreateIndex("dbo.DetailPret", "DVD_id1");
            CreateIndex("dbo.DetailPret", "Pret_id1");
            AddForeignKey("dbo.DetailPret", "DVD_id1", "dbo.DVD", "id");
            AddForeignKey("dbo.DetailPret", "Pret_id1", "dbo.Pret", "id");
            DropColumn("dbo.Films", "synopsis");
            DropColumn("dbo.DVD", "DVDID");
            DropColumn("dbo.DVD", "FilmID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVD", "FilmID", c => c.Int(nullable: false));
            AddColumn("dbo.DVD", "DVDID", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "synopsis", c => c.String());
            DropForeignKey("dbo.DetailPret", "Pret_id1", "dbo.Pret");
            DropForeignKey("dbo.DetailPret", "DVD_id1", "dbo.DVD");
            DropIndex("dbo.DetailPret", new[] { "Pret_id1" });
            DropIndex("dbo.DetailPret", new[] { "DVD_id1" });
            DropIndex("dbo.DVD", new[] { "films_id" });
            AlterColumn("dbo.DetailPret", "Pret_id", c => c.Int());
            AlterColumn("dbo.DetailPret", "DVD_id", c => c.Int());
            AlterColumn("dbo.DVD", "Films_id", c => c.Int());
            DropColumn("dbo.DetailPret", "Pret_id1");
            DropColumn("dbo.DetailPret", "DVD_id1");
            DropColumn("dbo.Films", "Genre_id");
            DropColumn("dbo.Films", "icon");
            DropColumn("dbo.Films", "Acteur_id");
            CreateIndex("dbo.DetailPret", "Pret_id");
            CreateIndex("dbo.DetailPret", "DVD_id");
            CreateIndex("dbo.DVD", "films_id");
            AddForeignKey("dbo.DetailPret", "Pret_id", "dbo.Pret", "id");
            AddForeignKey("dbo.DetailPret", "DVD_id", "dbo.DVD", "id");
        }
    }
}
