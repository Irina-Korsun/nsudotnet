namespace TestConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActualFlightsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SeatsCount = c.Int(nullable: false),
                        TicketsSold = c.Int(nullable: false),
                        TicketsReturned = c.Int(nullable: false),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArivalDateTime = c.DateTime(nullable: false),
                        Aircraft_ID = c.Long(),
                        Flight_ID = c.Long(),
                        FlightStatus_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AircraftsBase", t => t.Aircraft_ID)
                .ForeignKey("dbo.FlightsBase", t => t.Flight_ID)
                .ForeignKey("dbo.FlightStatusesBase", t => t.FlightStatus_ID)
                .Index(t => t.Aircraft_ID)
                .Index(t => t.Flight_ID)
                .Index(t => t.FlightStatus_ID);
            
            CreateTable(
                "dbo.AircraftsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NumberOfFlights = c.Int(nullable: false),
                        AircraftType_ID = c.Long(),
                        TechCheck_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AircraftTypesBase", t => t.AircraftType_ID)
                .ForeignKey("dbo.TechChecksBase", t => t.TechCheck_ID)
                .Index(t => t.AircraftType_ID)
                .Index(t => t.TechCheck_ID);
            
            CreateTable(
                "dbo.AircraftTypesBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TechChecksBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        MustBeFixed = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FlightsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PassengersCount = c.Int(nullable: false),
                        Category_ID = c.Long(),
                        Route_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FlightCategoriesBase", t => t.Category_ID)
                .ForeignKey("dbo.ArivalAirportsBase", t => t.Route_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Route_ID);
            
            CreateTable(
                "dbo.FlightCategoriesBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArivalAirportsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Town = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FlightStatusesBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BrigadesBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChildsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        ParentRefId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeesBase", t => t.ParentRefId, cascadeDelete: true)
                .Index(t => t.ParentRefId);
            
            CreateTable(
                "dbo.EmployeesBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DepartmentRefId = c.Long(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        Brigade_ID = c.Long(),
                        Position_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BrigadesBase", t => t.Brigade_ID)
                .ForeignKey("dbo.DepartmentsBase", t => t.DepartmentRefId, cascadeDelete: true)
                .ForeignKey("dbo.PositionsBase", t => t.Position_ID)
                .Index(t => t.DepartmentRefId)
                .Index(t => t.Brigade_ID)
                .Index(t => t.Position_ID);
            
            CreateTable(
                "dbo.DepartmentsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Chief_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeesBase", t => t.Chief_ID)
                .Index(t => t.Chief_ID);
            
            CreateTable(
                "dbo.PositionsBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MedicCheckPeriod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicalChecksBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Valid = c.Boolean(nullable: false),
                        Employee_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeesBase", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.SceduleBase",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArivalDateTime = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        AircraftType_ID = c.Long(),
                        Flight_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AircraftTypesBase", t => t.AircraftType_ID)
                .ForeignKey("dbo.FlightsBase", t => t.Flight_ID)
                .Index(t => t.AircraftType_ID)
                .Index(t => t.Flight_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SceduleBase", "Flight_ID", "dbo.FlightsBase");
            DropForeignKey("dbo.SceduleBase", "AircraftType_ID", "dbo.AircraftTypesBase");
            DropForeignKey("dbo.MedicalChecksBase", "Employee_ID", "dbo.EmployeesBase");
            DropForeignKey("dbo.EmployeesBase", "Position_ID", "dbo.PositionsBase");
            DropForeignKey("dbo.EmployeesBase", "DepartmentRefId", "dbo.DepartmentsBase");
            DropForeignKey("dbo.DepartmentsBase", "Chief_ID", "dbo.EmployeesBase");
            DropForeignKey("dbo.ChildsBase", "ParentRefId", "dbo.EmployeesBase");
            DropForeignKey("dbo.EmployeesBase", "Brigade_ID", "dbo.BrigadesBase");
            DropForeignKey("dbo.ActualFlightsBase", "FlightStatus_ID", "dbo.FlightStatusesBase");
            DropForeignKey("dbo.ActualFlightsBase", "Flight_ID", "dbo.FlightsBase");
            DropForeignKey("dbo.FlightsBase", "Route_ID", "dbo.ArivalAirportsBase");
            DropForeignKey("dbo.FlightsBase", "Category_ID", "dbo.FlightCategoriesBase");
            DropForeignKey("dbo.ActualFlightsBase", "Aircraft_ID", "dbo.AircraftsBase");
            DropForeignKey("dbo.AircraftsBase", "TechCheck_ID", "dbo.TechChecksBase");
            DropForeignKey("dbo.AircraftsBase", "AircraftType_ID", "dbo.AircraftTypesBase");
            DropIndex("dbo.SceduleBase", new[] { "Flight_ID" });
            DropIndex("dbo.SceduleBase", new[] { "AircraftType_ID" });
            DropIndex("dbo.MedicalChecksBase", new[] { "Employee_ID" });
            DropIndex("dbo.DepartmentsBase", new[] { "Chief_ID" });
            DropIndex("dbo.EmployeesBase", new[] { "Position_ID" });
            DropIndex("dbo.EmployeesBase", new[] { "Brigade_ID" });
            DropIndex("dbo.EmployeesBase", new[] { "DepartmentRefId" });
            DropIndex("dbo.ChildsBase", new[] { "ParentRefId" });
            DropIndex("dbo.FlightsBase", new[] { "Route_ID" });
            DropIndex("dbo.FlightsBase", new[] { "Category_ID" });
            DropIndex("dbo.AircraftsBase", new[] { "TechCheck_ID" });
            DropIndex("dbo.AircraftsBase", new[] { "AircraftType_ID" });
            DropIndex("dbo.ActualFlightsBase", new[] { "FlightStatus_ID" });
            DropIndex("dbo.ActualFlightsBase", new[] { "Flight_ID" });
            DropIndex("dbo.ActualFlightsBase", new[] { "Aircraft_ID" });
            DropTable("dbo.SceduleBase");
            DropTable("dbo.MedicalChecksBase");
            DropTable("dbo.PositionsBase");
            DropTable("dbo.DepartmentsBase");
            DropTable("dbo.EmployeesBase");
            DropTable("dbo.ChildsBase");
            DropTable("dbo.BrigadesBase");
            DropTable("dbo.FlightStatusesBase");
            DropTable("dbo.ArivalAirportsBase");
            DropTable("dbo.FlightCategoriesBase");
            DropTable("dbo.FlightsBase");
            DropTable("dbo.TechChecksBase");
            DropTable("dbo.AircraftTypesBase");
            DropTable("dbo.AircraftsBase");
            DropTable("dbo.ActualFlightsBase");
        }
    }
}
