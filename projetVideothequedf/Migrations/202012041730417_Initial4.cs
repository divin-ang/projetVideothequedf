namespace projetVideothequedf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DVD", "films_id", "dbo.Films");
            DropIndex("dbo.DVD", new[] { "films_id" });
            AddColumn("dbo.DVD", "Films_id1", c => c.Int());
            AlterColumn("dbo.DVD", "Films_id", c => c.Int(nullable: false));
            CreateIndex("dbo.DVD", "Films_id1");
            AddForeignKey("dbo.DVD", "Films_id1", "dbo.Films", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVD", "Films_id1", "dbo.Films");
            DropIndex("dbo.DVD", new[] { "Films_id1" });
            AlterColumn("dbo.DVD", "Films_id", c => c.Int());
            DropColumn("dbo.DVD", "Films_id1");
            CreateIndex("dbo.DVD", "films_id");
            AddForeignKey("dbo.DVD", "films_id", "dbo.Films", "id");
        }
    }
}
