namespace CollectionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CurrencyId = c.Long(),
                        ClientToccId = c.Long(),
                        CashPointId = c.Long(),
                        ClientId = c.Long(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashPoints", t => t.CashPointId)
                .ForeignKey("dbo.ClientToccs", t => t.ClientToccId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .Index(t => t.CurrencyId)
                .Index(t => t.ClientToccId)
                .Index(t => t.CashPointId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.CashPoints",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ClientToccId = c.Long(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientToccs", t => t.ClientToccId)
                .Index(t => t.ClientToccId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        BIN = c.String(),
                        Address = c.String(),
                        PostIndex = c.String(),
                        ReportGroup1 = c.Int(),
                        ReportGroup2 = c.Int(),
                        ReportGroup3 = c.Int(),
                        ReportGroup4 = c.Int(),
                        ClisubfmlId = c.Long(),
                        CityId = c.Long(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Clisubfmls", t => t.ClisubfmlId)
                .Index(t => t.ClisubfmlId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientToccs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClientId = c.Long(nullable: false),
                        CashCentreId = c.Long(nullable: false),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashCentres", t => t.CashCentreId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.CashCentreId);
            
            CreateTable(
                "dbo.CashCentres",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        TimeZone = c.String(),
                        CityId = c.Long(nullable: false),
                        ParentId = c.Long(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.CashCentres", t => t.ParentId)
                .Index(t => t.CityId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Clisubfmls",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CurrCode = c.String(),
                        SellRate = c.Single(nullable: false),
                        Locked = c.Boolean(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CountingConfigs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        TypeDeposit = c.Int(nullable: false),
                        DateDeposit = c.Int(nullable: false),
                        DateCollect = c.Int(nullable: false),
                        DatePayment = c.Int(nullable: false),
                        DatePacking = c.Int(nullable: false),
                        Bag = c.Int(nullable: false),
                        Wallet = c.Int(nullable: false),
                        Currency = c.Int(nullable: false),
                        Deposit1 = c.Int(nullable: false),
                        Deposit2 = c.Int(nullable: false),
                        Deposit3 = c.Int(nullable: false),
                        Deposit4 = c.Int(nullable: false),
                        Deposit5 = c.Int(nullable: false),
                        Deposit6 = c.Int(nullable: false),
                        Deposit7 = c.Int(nullable: false),
                        DeclaredNote = c.Int(nullable: false),
                        DeclaredCoin = c.Int(nullable: false),
                        DeclaredOther = c.Int(nullable: false),
                        OpenCard = c.Int(nullable: false),
                        DateDepositNull = c.Int(nullable: false),
                        DateCollectNull = c.Int(nullable: false),
                        DatePaymentNull = c.Int(nullable: false),
                        DatePackingNull = c.Int(nullable: false),
                        BagNull = c.Int(nullable: false),
                        WalletNull = c.Int(nullable: false),
                        CurrencyNull = c.Int(nullable: false),
                        Deposit1Null = c.Int(nullable: false),
                        Deposit2Null = c.Int(nullable: false),
                        Deposit3Null = c.Int(nullable: false),
                        Deposit4Null = c.Int(nullable: false),
                        Deposit5Null = c.Int(nullable: false),
                        Deposit6Null = c.Int(nullable: false),
                        Deposit7Null = c.Int(nullable: false),
                        DeclaredNoteNull = c.Int(nullable: false),
                        DeclaredCoinNull = c.Int(nullable: false),
                        DeclaredOtherNull = c.Int(nullable: false),
                        OpenCardNull = c.Int(nullable: false),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Denominations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValidDate = c.DateTime(nullable: false),
                        CurrencyId = c.Long(),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Creation = c.DateTime(),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        TypeDeposit = c.Int(nullable: false),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.String(maxLength: 128),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Creation = c.DateTime(nullable: false),
                        LastUpdateUser = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                        Code = c.String(),
                        Reference = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        CashCentreId = c.Long(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashCentres", t => t.CashCentreId)
                .Index(t => t.CashCentreId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CashCentreId", "dbo.CashCentres");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Denominations", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClisubfmlId", "dbo.Clisubfmls");
            DropForeignKey("dbo.ClientToccs", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.CashPoints", "ClientToccId", "dbo.ClientToccs");
            DropForeignKey("dbo.ClientToccs", "CashCentreId", "dbo.CashCentres");
            DropForeignKey("dbo.CashCentres", "ParentId", "dbo.CashCentres");
            DropForeignKey("dbo.CashCentres", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Accounts", "ClientToccId", "dbo.ClientToccs");
            DropForeignKey("dbo.Clients", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Accounts", "CashPointId", "dbo.CashPoints");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CashCentreId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Denominations", new[] { "CurrencyId" });
            DropIndex("dbo.CashCentres", new[] { "ParentId" });
            DropIndex("dbo.CashCentres", new[] { "CityId" });
            DropIndex("dbo.ClientToccs", new[] { "CashCentreId" });
            DropIndex("dbo.ClientToccs", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "CityId" });
            DropIndex("dbo.Clients", new[] { "ClisubfmlId" });
            DropIndex("dbo.CashPoints", new[] { "ClientToccId" });
            DropIndex("dbo.Accounts", new[] { "ClientId" });
            DropIndex("dbo.Accounts", new[] { "CashPointId" });
            DropIndex("dbo.Accounts", new[] { "ClientToccId" });
            DropIndex("dbo.Accounts", new[] { "CurrencyId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Transactions");
            DropTable("dbo.Rules");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Denominations");
            DropTable("dbo.CountingConfigs");
            DropTable("dbo.Currencies");
            DropTable("dbo.Clisubfmls");
            DropTable("dbo.CashCentres");
            DropTable("dbo.ClientToccs");
            DropTable("dbo.Cities");
            DropTable("dbo.Clients");
            DropTable("dbo.CashPoints");
            DropTable("dbo.Accounts");
        }
    }
}
