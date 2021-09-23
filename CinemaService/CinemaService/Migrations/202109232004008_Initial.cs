namespace CinemaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Director = c.String(nullable: false, maxLength: 50),
                        Duration = c.Int(nullable: false),
                        PicturePath = c.String(),
                        Studio = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                        Genre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        RegistrationDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
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
                "dbo.Projections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeShowing = c.DateTime(nullable: false),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                        SoldOut = c.Boolean(nullable: false),
                        Admin_Id = c.String(maxLength: 128),
                        Movie_Id = c.Int(nullable: false),
                        ProjectionType_Id = c.Int(nullable: false),
                        Theater_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Admin_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProjectionTypes", t => t.ProjectionType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Theaters", t => t.Theater_Id, cascadeDelete: true)
                .Index(t => t.Admin_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.ProjectionType_Id)
                .Index(t => t.Theater_Id);
            
            CreateTable(
                "dbo.ProjectionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Theaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Free = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.Int(nullable: false),
                        Free = c.Boolean(nullable: false),
                        Theater_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theaters", t => t.Theater_Id, cascadeDelete: true)
                .Index(t => t.Theater_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePurchased = c.DateTime(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Projection_Id = c.Int(nullable: false),
                        Seat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Projections", t => t.Projection_Id, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.Seat_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Projection_Id)
                .Index(t => t.Seat_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TheaterProjectionTypes",
                c => new
                    {
                        Theater_Id = c.Int(nullable: false),
                        ProjectionType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Theater_Id, t.ProjectionType_Id })
                .ForeignKey("dbo.Theaters", t => t.Theater_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProjectionTypes", t => t.ProjectionType_Id, cascadeDelete: true)
                .Index(t => t.Theater_Id)
                .Index(t => t.ProjectionType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tickets", "Seat_Id", "dbo.Seats");
            DropForeignKey("dbo.Tickets", "Projection_Id", "dbo.Projections");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projections", "Theater_Id", "dbo.Theaters");
            DropForeignKey("dbo.Projections", "ProjectionType_Id", "dbo.ProjectionTypes");
            DropForeignKey("dbo.Seats", "Theater_Id", "dbo.Theaters");
            DropForeignKey("dbo.TheaterProjectionTypes", "ProjectionType_Id", "dbo.ProjectionTypes");
            DropForeignKey("dbo.TheaterProjectionTypes", "Theater_Id", "dbo.Theaters");
            DropForeignKey("dbo.Projections", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Projections", "Admin_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TheaterProjectionTypes", new[] { "ProjectionType_Id" });
            DropIndex("dbo.TheaterProjectionTypes", new[] { "Theater_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tickets", new[] { "Seat_Id" });
            DropIndex("dbo.Tickets", new[] { "Projection_Id" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Seats", new[] { "Theater_Id" });
            DropIndex("dbo.Projections", new[] { "Theater_Id" });
            DropIndex("dbo.Projections", new[] { "ProjectionType_Id" });
            DropIndex("dbo.Projections", new[] { "Movie_Id" });
            DropIndex("dbo.Projections", new[] { "Admin_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.TheaterProjectionTypes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tickets");
            DropTable("dbo.Seats");
            DropTable("dbo.Theaters");
            DropTable("dbo.ProjectionTypes");
            DropTable("dbo.Projections");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Movies");
        }
    }
}
