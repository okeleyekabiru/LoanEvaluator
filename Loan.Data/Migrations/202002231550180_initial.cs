namespace Loan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderName = c.String(),
                        UniqueCountVisit = c.Int(nullable: false),
                        CountVisit = c.Int(nullable: false),
                        AverageAmountRequest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapLoans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Loansite = c.String(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumLoan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumLoan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        websitelink = c.String(nullable: false),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Subscribeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSubscribed = c.Boolean(nullable: false),
                        Subscribe = c.Int(nullable: false),
                        UserId = c.String(),
                        PaymentStatus = c.String(),
                        AmountSubscribed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubscribedMonth = c.Int(nullable: false),
                        UserName = c.String(),
                        DateSubscribed = c.DateTime(nullable: false),
                        SubscribtionExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribeds");
            DropTable("dbo.MapLoans");
            DropTable("dbo.LoanProviders");
        }
    }
}
