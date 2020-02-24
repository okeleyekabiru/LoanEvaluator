namespace Loan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clicker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClickTrackers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvideName = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClickTrackers");
        }
    }
}
