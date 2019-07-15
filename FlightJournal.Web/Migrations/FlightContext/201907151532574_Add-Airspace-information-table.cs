namespace FlightJournal.Web.Migrations.FlightContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAirspaceinformationtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AirspaceInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isOpen = c.Boolean(nullable: false),
                        PilotId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Altitude = c.Int(nullable: false),
                        FlightLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pilots", t => t.PilotId)
                .Index(t => t.PilotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AirspaceInfoes", "PilotId", "dbo.Pilots");
            DropIndex("dbo.AirspaceInfoes", new[] { "PilotId" });
            DropTable("dbo.AirspaceInfoes");
        }
    }
}
