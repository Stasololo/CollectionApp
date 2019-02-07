namespace CollectionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returnDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Accounts", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashPoints", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashPoints", "LastUpdateUser", c => c.String());
            AddColumn("dbo.CashPoints", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Clients", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientToccs", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientToccs", "LastUpdateUser", c => c.String());
            AddColumn("dbo.ClientToccs", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashCentres", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashCentres", "LastUpdateUser", c => c.String());
            AddColumn("dbo.CashCentres", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clisubfmls", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clisubfmls", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Clisubfmls", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Currencies", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Currencies", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Currencies", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Denominations", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Denominations", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Denominations", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Transactions", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "LastUpdate");
            DropColumn("dbo.Transactions", "LastUpdateUser");
            DropColumn("dbo.Transactions", "Creation");
            DropColumn("dbo.Denominations", "LastUpdate");
            DropColumn("dbo.Denominations", "LastUpdateUser");
            DropColumn("dbo.Denominations", "Creation");
            DropColumn("dbo.Currencies", "LastUpdate");
            DropColumn("dbo.Currencies", "LastUpdateUser");
            DropColumn("dbo.Currencies", "Creation");
            DropColumn("dbo.Clisubfmls", "LastUpdate");
            DropColumn("dbo.Clisubfmls", "LastUpdateUser");
            DropColumn("dbo.Clisubfmls", "Creation");
            DropColumn("dbo.CashCentres", "LastUpdate");
            DropColumn("dbo.CashCentres", "LastUpdateUser");
            DropColumn("dbo.CashCentres", "Creation");
            DropColumn("dbo.ClientToccs", "LastUpdate");
            DropColumn("dbo.ClientToccs", "LastUpdateUser");
            DropColumn("dbo.ClientToccs", "Creation");
            DropColumn("dbo.Clients", "LastUpdate");
            DropColumn("dbo.Clients", "LastUpdateUser");
            DropColumn("dbo.Clients", "Creation");
            DropColumn("dbo.CashPoints", "LastUpdate");
            DropColumn("dbo.CashPoints", "LastUpdateUser");
            DropColumn("dbo.CashPoints", "Creation");
            DropColumn("dbo.Accounts", "LastUpdate");
            DropColumn("dbo.Accounts", "LastUpdateUser");
            DropColumn("dbo.Accounts", "Creation");
        }
    }
}
