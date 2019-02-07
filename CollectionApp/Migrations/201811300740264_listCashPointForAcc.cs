namespace CollectionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listCashPointForAcc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "CashPointId", "dbo.CashPoints");
            DropIndex("dbo.Accounts", new[] { "CashPointId" });
            CreateTable(
                "dbo.CashPointAccounts",
                c => new
                    {
                        CashPoint_Id = c.Long(nullable: false),
                        Account_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.CashPoint_Id, t.Account_Id })
                .ForeignKey("dbo.CashPoints", t => t.CashPoint_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.CashPoint_Id)
                .Index(t => t.Account_Id);
            
            DropColumn("dbo.Accounts", "CashPointId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "CashPointId", c => c.Long());
            DropForeignKey("dbo.CashPointAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.CashPointAccounts", "CashPoint_Id", "dbo.CashPoints");
            DropIndex("dbo.CashPointAccounts", new[] { "Account_Id" });
            DropIndex("dbo.CashPointAccounts", new[] { "CashPoint_Id" });
            DropTable("dbo.CashPointAccounts");
            CreateIndex("dbo.Accounts", "CashPointId");
            AddForeignKey("dbo.Accounts", "CashPointId", "dbo.CashPoints", "Id");
        }
    }
}
