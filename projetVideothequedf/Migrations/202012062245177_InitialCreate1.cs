namespace projetVideothequedf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GenreFilms", "Genre_id", "dbo.Genre");
            DropForeignKey("dbo.GenreFilms", "Films_id", "dbo.Films");
            DropIndex("dbo.GenreFilms", new[] { "Genre_id" });
            DropIndex("dbo.GenreFilms", new[] { "Films_id" });
            AddColumn("dbo.Films", "Genre", c => c.String());
            DropColumn("dbo.Films", "Genre_id");
            DropTable("dbo.Genre");
            DropTable("dbo.GenreFilms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreFilms",
                c => new
                    {
                        Genre_id = c.Int(nullable: false),
                        Films_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_id, t.Films_id });
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Films", "Genre_id", c => c.Int(nullable: false));
            DropColumn("dbo.Films", "Genre");
            CreateIndex("dbo.GenreFilms", "Films_id");
            CreateIndex("dbo.GenreFilms", "Genre_id");
            AddForeignKey("dbo.GenreFilms", "Films_id", "dbo.Films", "id", cascadeDelete: true);
            AddForeignKey("dbo.GenreFilms", "Genre_id", "dbo.Genre", "id", cascadeDelete: true);
        }
    }
}
