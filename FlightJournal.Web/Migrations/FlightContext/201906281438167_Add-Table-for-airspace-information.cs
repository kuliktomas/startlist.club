namespace FlightJournal.Web.Migrations.FlightContext
{
    using System.Data.Entity.Migrations;

    public partial class AddTableforairspaceinformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.AirspaceInfo",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   isOpen = c.Boolean(defaultValue: false),
                   PilotId = c.Int(nullable: false),
                   Date = c.DateTime(),
                   Altitude = c.Int(),
                   FlightLevel = c.Int(),
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.Pilots", t => t.PilotId, cascadeDelete: false)
               .Index(t => t.PilotId);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AirspaceInfo", "PilotId");
            DropTable("dbo.AirspaceInfo");
        }
    }
}
