namespace DBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1241234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Longtitude", c => c.Double(nullable: true));
            AlterColumn("dbo.Addresses", "Latitude", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Latitude", c => c.String());
            AlterColumn("dbo.Addresses", "Longtitude", c => c.String());
        }
    }
}
