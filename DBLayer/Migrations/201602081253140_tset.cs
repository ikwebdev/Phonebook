namespace DBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        House = c.String(),
                        Longtitude = c.String(),
                        Latitude = c.String(),
                        Steeet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.Steeet_Id, cascadeDelete: true)
                .Index(t => t.Steeet_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person_Id = c.Int(nullable: false),
                        Mobile = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        street = c.String(),
                        city_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.city_Id, cascadeDelete: true)
                .Index(t => t.city_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        city = c.String(),
                        country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.country_Id, cascadeDelete: true)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonAddresses",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Address_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Steeet_Id", "dbo.Streets");
            DropForeignKey("dbo.Streets", "city_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "country_Id", "dbo.Countries");
            DropForeignKey("dbo.People", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Phones", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PersonAddresses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.PersonAddresses", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonAddresses", new[] { "Address_Id" });
            DropIndex("dbo.PersonAddresses", new[] { "Person_Id" });
            DropIndex("dbo.Cities", new[] { "country_Id" });
            DropIndex("dbo.Streets", new[] { "city_Id" });
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            DropIndex("dbo.People", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "Steeet_Id" });
            DropTable("dbo.PersonAddresses");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Streets");
            DropTable("dbo.Users");
            DropTable("dbo.Phones");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
