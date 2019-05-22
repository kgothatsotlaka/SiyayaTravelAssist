namespace SiyayaTravelAssist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingStatus = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        BookingReference = c.String(),
                        BookingOrder = c.String(),
                        PaymentBalance = c.Double(nullable: false),
                        PaymentType = c.String(),
                        PaymentStatus = c.String(),
                        AdditionalInformation = c.String(),
                        NumberOfPassengers = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        BookingTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingTypes", t => t.BookingTypeId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId)
                .Index(t => t.BookingTypeId);
            
            CreateTable(
                "dbo.BookingTrips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .Index(t => t.BookingId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseNumber = c.String(),
                        LicenseExpiryDate = c.DateTime(nullable: false),
                        LicenseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicenseTypes", t => t.LicenseTypeId)
                .Index(t => t.LicenseTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        IdentityNumber = c.String(),
                        Telephone = c.String(),
                        EmployeeTypeId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        NationalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.EmployeeTypeId)
                .Index(t => t.GenderId)
                .Index(t => t.TitleId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicenseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PickUpTime = c.DateTime(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                        PassengerId = c.Int(nullable: false),
                        DropOffLocation_Id = c.Int(),
                        PickupLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.DropOffLocation_Id)
                .ForeignKey("dbo.Passengers", t => t.PassengerId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.PickupLocation_Id)
                .ForeignKey("dbo.BookingTrips", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PassengerId)
                .Index(t => t.DropOffLocation_Id)
                .Index(t => t.PickupLocation_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        DropOffTrip_Id = c.Int(),
                        PickupTrip_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.DropOffTrip_Id)
                .ForeignKey("dbo.Trips", t => t.PickupTrip_Id)
                .Index(t => t.DropOffTrip_Id)
                .Index(t => t.PickupTrip_Id);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        LastName = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleColorId = c.Int(nullable: false),
                        VehicleGroupId = c.Int(nullable: false),
                        VehicleBrandTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleBrandTypes", t => t.VehicleBrandTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleColors", t => t.VehicleColorId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleGroups", t => t.VehicleGroupId, cascadeDelete: true)
                .Index(t => t.VehicleColorId)
                .Index(t => t.VehicleGroupId)
                .Index(t => t.VehicleBrandTypeId);
            
            CreateTable(
                "dbo.VehicleBrandTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        VehicleModelTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModelTypes", t => t.VehicleModelTypeId, cascadeDelete: true)
                .Index(t => t.VehicleModelTypeId);
            
            CreateTable(
                "dbo.VehicleModelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientReference = c.String(),
                        FirstName = c.String(),
                        Address = c.String(),
                        EmailAddress = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "Id", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "BookingTypeId", "dbo.BookingTypes");
            DropForeignKey("dbo.BookingTrips", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.BookingTrips", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleGroupId", "dbo.VehicleGroups");
            DropForeignKey("dbo.Vehicles", "VehicleColorId", "dbo.VehicleColors");
            DropForeignKey("dbo.Vehicles", "VehicleBrandTypeId", "dbo.VehicleBrandTypes");
            DropForeignKey("dbo.VehicleBrandTypes", "VehicleModelTypeId", "dbo.VehicleModelTypes");
            DropForeignKey("dbo.Trips", "Id", "dbo.BookingTrips");
            DropForeignKey("dbo.Trips", "PickupLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.Trips", "PassengerId", "dbo.Passengers");
            DropForeignKey("dbo.Trips", "DropOffLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "PickupTrip_Id", "dbo.Trips");
            DropForeignKey("dbo.Locations", "DropOffTrip_Id", "dbo.Trips");
            DropForeignKey("dbo.BookingTrips", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "LicenseTypeId", "dbo.LicenseTypes");
            DropForeignKey("dbo.Employees", "Id", "dbo.Drivers");
            DropForeignKey("dbo.Employees", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Employees", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes");
            DropIndex("dbo.Quotes", new[] { "Id" });
            DropIndex("dbo.VehicleBrandTypes", new[] { "VehicleModelTypeId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleBrandTypeId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleGroupId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleColorId" });
            DropIndex("dbo.Locations", new[] { "PickupTrip_Id" });
            DropIndex("dbo.Locations", new[] { "DropOffTrip_Id" });
            DropIndex("dbo.Trips", new[] { "PickupLocation_Id" });
            DropIndex("dbo.Trips", new[] { "DropOffLocation_Id" });
            DropIndex("dbo.Trips", new[] { "PassengerId" });
            DropIndex("dbo.Trips", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "NationalityId" });
            DropIndex("dbo.Employees", new[] { "TitleId" });
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropIndex("dbo.Employees", new[] { "EmployeeTypeId" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Drivers", new[] { "LicenseTypeId" });
            DropIndex("dbo.BookingTrips", new[] { "VehicleId" });
            DropIndex("dbo.BookingTrips", new[] { "DriverId" });
            DropIndex("dbo.BookingTrips", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "BookingTypeId" });
            DropIndex("dbo.Bookings", new[] { "ClientId" });
            DropTable("dbo.Quotes");
            DropTable("dbo.Clients");
            DropTable("dbo.BookingTypes");
            DropTable("dbo.VehicleGroups");
            DropTable("dbo.VehicleColors");
            DropTable("dbo.VehicleModelTypes");
            DropTable("dbo.VehicleBrandTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Passengers");
            DropTable("dbo.Locations");
            DropTable("dbo.Trips");
            DropTable("dbo.LicenseTypes");
            DropTable("dbo.Titles");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Genders");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.Drivers");
            DropTable("dbo.BookingTrips");
            DropTable("dbo.Bookings");
        }
    }
}
