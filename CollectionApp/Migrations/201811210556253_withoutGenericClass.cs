namespace CollectionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withoutGenericClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "Creation");
            DropColumn("dbo.Accounts", "LastUpdateUser");
            DropColumn("dbo.Accounts", "LastUpdate");
            DropColumn("dbo.CashPoints", "Creation");
            DropColumn("dbo.CashPoints", "LastUpdateUser");
            DropColumn("dbo.CashPoints", "LastUpdate");
            DropColumn("dbo.Clients", "Creation");
            DropColumn("dbo.Clients", "LastUpdateUser");
            DropColumn("dbo.Clients", "LastUpdate");
            DropColumn("dbo.CashCentres", "Creation");
            DropColumn("dbo.CashCentres", "LastUpdateUser");
            DropColumn("dbo.CashCentres", "LastUpdate");
            DropColumn("dbo.Clisubfmls", "Creation");
            DropColumn("dbo.Clisubfmls", "LastUpdateUser");
            DropColumn("dbo.Clisubfmls", "LastUpdate");
            DropColumn("dbo.Currencies", "Creation");
            DropColumn("dbo.Currencies", "LastUpdateUser");
            DropColumn("dbo.Currencies", "LastUpdate");
            DropColumn("dbo.Denominations", "Creation");
            DropColumn("dbo.Denominations", "LastUpdateUser");
            DropColumn("dbo.Denominations", "LastUpdate");
            DropColumn("dbo.Transactions", "Creation");
            DropColumn("dbo.Transactions", "LastUpdateUser");
            DropColumn("dbo.Transactions", "LastUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Transactions", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Denominations", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Denominations", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Denominations", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Currencies", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Currencies", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Currencies", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clisubfmls", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clisubfmls", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Clisubfmls", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashCentres", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashCentres", "LastUpdateUser", c => c.String());
            AddColumn("dbo.CashCentres", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Clients", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashPoints", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CashPoints", "LastUpdateUser", c => c.String());
            AddColumn("dbo.CashPoints", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "LastUpdateUser", c => c.String());
            AddColumn("dbo.Accounts", "Creation", c => c.DateTime(nullable: false));
        }
    }
}
