namespace CollectionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientTocc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClientToccs", "Creation");
            DropColumn("dbo.ClientToccs", "LastUpdateUser");
            DropColumn("dbo.ClientToccs", "LastUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientToccs", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientToccs", "LastUpdateUser", c => c.String());
            AddColumn("dbo.ClientToccs", "Creation", c => c.DateTime(nullable: false));
        }
    }
}
