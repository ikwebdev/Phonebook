namespace DBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _124123 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Longtitude", c => c.Double());
            AlterColumn("dbo.Addresses", "Latitude", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Addresses", "Longtitude", c => c.Double(nullable: false));
        }
    }
}
