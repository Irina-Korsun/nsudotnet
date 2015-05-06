using System;
using System.Linq;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using System.Data.SqlClient;
using System.Configuration;

namespace TestConsole
{
    class Program
    {
        private BaseContext context;

        static void Main(string[] args)
        {
            var t = new Program();
            t.Start();
        }
        private void Start()
        {
            this.context = new BaseContext();
            context.Database.Delete();
            context.SaveChanges();
            Console.WriteLine("The Data Base was Dropped");
            AddDataToDataBase();
            Console.WriteLine("Data added");
            
        }
        private void AddDataToDataBase()
        {    
            CreateAircraftTypes();
            CreateArivalAirports();
            CreateFlightCategories();
            CreateFlightStatuses();
            CreateTechChecks();
            CreateAircrafts();
            CreateFlights();
            CreateActualFlights();
            CreateSchedule();

            CreatePositions();
            CreateBrigades();
            CreateDepartments();
        }
        private void DropTables()
        {
            Drop("[BrigadesBase]");
            Drop("[PositionsBase]");
            Drop("dbo.ActualFlightsBase");
            Drop("dbo.FlightsBase");
            Drop("dbo.AircraftsBase");
            Drop("dbo.TechChecksBase");
            Drop("dbo.FlightStatusesBase");
            Drop("dbo.FlightCategoriesBase");
            Drop("dbo.ArivalAirportsBase");
            Drop("dbo.AircraftTypesBase");            
        }
        private void Drop(string TableName)
        {
            bool TableExists = false;
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnetionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT (*) FROM DataBaseLab";
                con.Open();
                if ((int)cmd.ExecuteScalar() > 0)
                    TableExists = true;
                else
                    TableExists = false;
            }
            if (TableExists == true)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DROP TABLE " + TableName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

             
        }
        private void CreateAircraftTypes()
        {
            CreateAircraftTypes("Boing777");
            CreateAircraftTypes("Boing666");
            CreateAircraftTypes("TU");
            CreateAircraftTypes("SU37");
            CreateAircraftTypes("Aerobus");
            CreateAircraftTypes("Boing-DreamFly");
            context.SaveChanges();
        }
        private void CreateAircraftTypes(string Name)
        {
            var type = new AircraftTypes() { Name = Name };
            context.AircraftTypesBase.Add(type);
        }
        private void CreateArivalAirports()
        {
            CreateArivalAirports("Domodedovo", "Russia", "Moskow");
            CreateArivalAirports("Vnukovo", "Russia", "Moskow");
            CreateArivalAirports("Tolmachevo", "Russia", "Novosibirsk");
            CreateArivalAirports("Manchester", "USA", "Manchester");
            CreateArivalAirports("Brisbane", "Australia", "Brisbane");
            CreateArivalAirports("Darwin", "Australia", "Darwin");
            CreateArivalAirports("Duboo City", "Australia", "Duboo");
            CreateArivalAirports("Melbourne", "Australia", "Melbourne");
            context.SaveChanges();
        }
        private void CreateArivalAirports(string Name, string Country, string Town)
        {
            var airport = new ArivalAirports() { Name = Name, Country = Country, Town = Town };
            context.ArivalAirportsBase.Add(airport);
        }
        private void CreateBrigades()
        {
            CreateBrigades("Brigade 1");
            CreateBrigades("Brigade 2");
            CreateBrigades("Brigade 3");
            CreateBrigades("Brigade 4");
            CreateBrigades("Brigade 5");
            CreateBrigades("Brigade 6");

        }
        private void CreateBrigades(string Name)
        {
            context.BrigadesBase.Add(new Brigades()
            {
                Name = Name
            });
        }
        private void CreateFlightCategories()
        {
            CreateFlightCategories("Passengers");
            CreateFlightCategories("Post");
            CreateFlightCategories("Regular");
            CreateFlightCategories("Not Regular");
            context.SaveChanges();

        }
        private void CreateFlightCategories(string Type)
        {
            context.FlightCategoriesBase.Add(new FlightCategories()
            {
                Type = Type
            });
        }
        private void CreateFlightStatuses()
        {
            CreateFlightStatuses("Canceled");
            CreateFlightStatuses("Ready");
            CreateFlightStatuses("Delayed");
            CreateFlightStatuses("Boarding");
            context.SaveChanges();

        }
        private void CreateFlightStatuses(string Type)
        {
            context.FlightStatusesBase.Add(new FlightStatuses()
            {
                Type = Type
            });
        }

        private void CreateTechChecks()
        {
            CreateTechChecks(true);
            CreateTechChecks(false);
            CreateTechChecks(true);
            CreateTechChecks(true);
            context.SaveChanges();
        }
        private void CreateTechChecks(bool MustBeFixed)
        {
            context.TechChecksBase.Add(new TechChecks()
            {
                Date = DateTime.Now,
                MustBeFixed = MustBeFixed,
                Created = DateTime.Now
            });
        }
        private void CreateAircrafts()
        {
            CreateAircrafts("Boing777", 1);
            CreateAircrafts("Boing666", 2);
            CreateAircrafts("TU", 3);
            CreateAircrafts("SU37", 4);
            context.SaveChanges();
        }
        private void CreateAircrafts(string AircraftType, long ID)
        {
            var t = context.AircraftTypesBase.Single(s => s.Name == AircraftType) as AircraftTypes;
            var c = context.TechChecksBase.Single(s => s.ID == ID) as TechChecks;
            context.AircraftsBase.Add(new Aircrafts()
            {
                AircraftType = t,
                TechCheck = c,
                NumberOfFlights = 0
            });
        }
        private void CreateFlights()
        {
            CreateFlights("Passengers", "Domodedovo");
            CreateFlights("Post", "Domodedovo");
            CreateFlights("Post", "Manchester");
            CreateFlights("Regular", "Brisbane");
            CreateFlights("Regular", "Duboo City");
            context.SaveChanges();
        }
        private void CreateFlights(string Category, string Route)
        {
            var t = context.FlightCategoriesBase.Single(s => s.Type == Category) as FlightCategories;
            var c = context.ArivalAirportsBase.Single(s => s.Name == Route) as ArivalAirports;
            context.FlightsBase.Add(new Flights()
            {
                Category = t,
                Route = c,
                PassengersCount = 9
            });
        }
        private void CreateActualFlights()
        {
            CreateActualFlights(1, 1, 1);
            CreateActualFlights(2, 1, 1);
            CreateActualFlights(3, 2, 2);
            CreateActualFlights(4, 2, 1);
            context.SaveChanges();
        }
        private void CreateActualFlights(int AircraftID, int FlightiD, int FlightStatusID)
        {
            var a = context.AircraftsBase.Single(s => s.ID == AircraftID) as Aircrafts;
            var f = context.FlightsBase.Single(s => s.ID == FlightiD) as Flights;
            var b = context.FlightStatusesBase.Single(s => s.ID == FlightStatusID) as FlightStatuses;
            context.ActualFlightsBase.Add(new ActualFlights
            {
                Flight = f,
                Aircraft = a,
                FlightStatus = b,
                SeatsCount = 10,
                TicketsSold = 5,
                TicketsReturned = 1,
                DepartureDateTime = DateTime.Now,
                ArivalDateTime = DateTime.Now
            });
        }
        private void CreatePositions()
        {
            CreatePositions("HRManager", 1);
            CreatePositions("Dispetcher", 2);
            CreatePositions("Programmer", 1);
            CreatePositions("Doctor", 4);
            CreatePositions("Teacher", 3);
            context.SaveChanges();
        }
        private void CreatePositions(string Name, int MedicCheckPeriod)
        {
            context.PositionsBase.Add(new Positions()
            {
                Name = Name,
                MedicCheckPeriod = MedicCheckPeriod
            });
        }
        private void CreateSchedule()
        {
            CreateSchedule(1, 1, 2000);
            CreateSchedule(1, 2, 3000);
            CreateSchedule(2, 3, 100);
            CreateSchedule(2, 4, 100);
            context.SaveChanges();
        }
         private void CreateSchedule(int AircraftTypeID, int FlightID, int Price){
             var a = context.AircraftTypesBase.Single(s => s.ID == AircraftTypeID) as AircraftTypes;
             var f = context.FlightsBase.Single(s => s.ID == FlightID) as Flights;
             context.ScheduleBase.Add(new Schedule
             {
                 AircraftType = a,
                 Flight = f,
                 DepartureDateTime = DateTime.Now,
                 ArivalDateTime = DateTime.Now,
                 Price = Price
             });
        }
         private void CreateDepartments()
         {
             CreateDepartments("HRDepartment");
             CreateDepartments("ProgramDepartment");
             CreateDepartments("EvilDepartment");
             CreateDepartments("ChocolateDepartment");
             context.SaveChanges();
         }
         private void CreateDepartments(string Name)
         {
             context.DepartmentsBase.Add(new Departments
             {
                 Name = Name,
                 Chief = null
             });
         }
    }

}
