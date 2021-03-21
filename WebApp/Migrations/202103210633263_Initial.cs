namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vAction = c.String(maxLength: 50, unicode: false),
                        vInput = c.String(maxLength: 200),
                        vOutput = c.String(maxLength: 200),
                        iResult = c.Int(),
                        dProcessTimestamp = c.DateTime(),
                        vClientInfo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventLog");
        }
    }
}
