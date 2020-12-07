namespace projetVideothequedf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pret", "pretID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pret", "pretID", c => c.Int(nullable: false));
        }
    }
}
