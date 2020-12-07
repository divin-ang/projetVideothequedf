namespace projetVideothequedf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pret", "clientID", "dbo.Client");
            DropIndex("dbo.DVD", new[] { "Films_id1" });
            DropIndex("dbo.DetailPret", new[] { "DVD_id1" });
            DropIndex("dbo.DetailPret", new[] { "Pret_id1" });
            DropIndex("dbo.Pret", new[] { "clientID" });
            DropColumn("dbo.DVD", "Films_id");
            DropColumn("dbo.DetailPret", "DVD_id");
            DropColumn("dbo.DetailPret", "Pret_id");
            RenameColumn(table: "dbo.DVD", name: "Films_id1", newName: "Films_id");
            RenameColumn(table: "dbo.DetailPret", name: "DVD_id1", newName: "DVD_id");
            RenameColumn(table: "dbo.DetailPret", name: "Pret_id1", newName: "Pret_id");
            RenameColumn(table: "dbo.Pret", name: "clientID", newName: "Clients_id");
            AlterColumn("dbo.DVD", "Films_id", c => c.Int());
            AlterColumn("dbo.DetailPret", "DVD_id", c => c.Int());
            AlterColumn("dbo.DetailPret", "Pret_id", c => c.Int());
            AlterColumn("dbo.Pret", "Clients_id", c => c.Int());
            CreateIndex("dbo.DVD", "Films_id");
            CreateIndex("dbo.DetailPret", "DVD_id");
            CreateIndex("dbo.DetailPret", "Pret_id");
            CreateIndex("dbo.Pret", "Clients_id");
            AddForeignKey("dbo.Pret", "Clients_id", "dbo.Client", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pret", "Clients_id", "dbo.Client");
            DropIndex("dbo.Pret", new[] { "Clients_id" });
            DropIndex("dbo.DetailPret", new[] { "Pret_id" });
            DropIndex("dbo.DetailPret", new[] { "DVD_id" });
            DropIndex("dbo.DVD", new[] { "Films_id" });
            AlterColumn("dbo.Pret", "Clients_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPret", "Pret_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPret", "DVD_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DVD", "Films_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Pret", name: "Clients_id", newName: "clientID");
            RenameColumn(table: "dbo.DetailPret", name: "Pret_id", newName: "Pret_id1");
            RenameColumn(table: "dbo.DetailPret", name: "DVD_id", newName: "DVD_id1");
            RenameColumn(table: "dbo.DVD", name: "Films_id", newName: "Films_id1");
            AddColumn("dbo.DetailPret", "Pret_id", c => c.Int(nullable: false));
            AddColumn("dbo.DetailPret", "DVD_id", c => c.Int(nullable: false));
            AddColumn("dbo.DVD", "Films_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Pret", "clientID");
            CreateIndex("dbo.DetailPret", "Pret_id1");
            CreateIndex("dbo.DetailPret", "DVD_id1");
            CreateIndex("dbo.DVD", "Films_id1");
            AddForeignKey("dbo.Pret", "clientID", "dbo.Client", "id", cascadeDelete: true);
        }
    }
}
