namespace CinemaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 80),
                        Director = c.String(nullable: false, maxLength: 50),
                        Duration = c.Int(nullable: false),
                        PicturePath = c.String(),
                        Studio = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projections",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateTimeShowing = c.DateTime(nullable: false),
                        MovieId = c.Int(nullable: false),
                        ProjectionTypeId = c.Int(nullable: false),
                        TheaterId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectionTypes", t => t.ProjectionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Theaters", t => t.TheaterId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.MovieId)
                .Index(t => t.ProjectionTypeId)
                .Index(t => t.TheaterId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProjectionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                        Theater_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theaters", t => t.Theater_Id)
                .Index(t => t.Theater_Id);
            
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
                        Free = c.Boolean(nullable: false),
                        TheaterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theaters", t => t.TheaterId, cascadeDelete: true)
                .Index(t => t.TheaterId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purchased = c.Boolean(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                        ProjectionId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProjectionId)
                .Index(t => t.SeatId)
                .Index(t => t.UserId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Projections", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projections", "TheaterId", "dbo.Theaters");
            DropForeignKey("dbo.Seats", "TheaterId", "dbo.Theaters");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Tickets", "ProjectionId", "dbo.Projections");
            DropForeignKey("dbo.ProjectionTypes", "Theater_Id", "dbo.Theaters");
            DropForeignKey("dbo.Projections", "ProjectionTypeId", "dbo.ProjectionTypes");
            DropForeignKey("dbo.Projections", "MovieId", "dbo.Movies");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "SeatId" });
            DropIndex("dbo.Tickets", new[] { "ProjectionId" });
            DropIndex("dbo.Seats", new[] { "TheaterId" });
            DropIndex("dbo.ProjectionTypes", new[] { "Theater_Id" });
            DropIndex("dbo.Projections", new[] { "UserId" });
            DropIndex("dbo.Projections", new[] { "TheaterId" });
            DropIndex("dbo.Projections", new[] { "ProjectionTypeId" });
            DropIndex("dbo.Projections", new[] { "MovieId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tickets");
            DropTable("dbo.Seats");
            DropTable("dbo.Theaters");
            DropTable("dbo.ProjectionTypes");
            DropTable("dbo.Projections");
            DropTable("dbo.Movies");
        }
    }
}
