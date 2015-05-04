using System;
using System.Linq;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;

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
            Drop();
            context.SaveChanges();

            CreateAircraftTypes();
            CreateArivalAirports();
            CreateFlightCategories();
            CreateFlightStatuses();
            CreatePositions();
            CreateTechChecks();

            context.SaveChanges();
                        
            //CreateAircrafts();
            //CreateFlights();
            //CreateActualFlights();
            //var t = context.AircraftTypesBase.Local.Single(s => s.Name == "Boing777") as AircraftTypes;
        }
        private void Drop()
        {

            foreach (var entity in context.AircraftTypesBase)
                context.AircraftTypesBase.Remove(entity);

            foreach (var entity in context.ArivalAirportsBase)
                context.ArivalAirportsBase.Remove(entity);

            foreach (var entity in context.AircraftsBase)
                context.AircraftsBase.Remove(entity);

            foreach (var entity in context.BrigadesBase)
                context.BrigadesBase.Remove(entity);

            foreach (var entity in context.FlightCategoriesBase)
                context.FlightCategoriesBase.Remove(entity);

            foreach (var entity in context.FlightsBase)
                context.FlightsBase.Remove(entity);

            foreach (var entity in context.FlightStatusesBase)
                context.FlightStatusesBase.Remove(entity);

            foreach (var entity in context.PositionsBase)
                context.PositionsBase.Remove(entity);

            foreach (var entity in context.TechChecksBase)
                context.TechChecksBase.Remove(entity);

        }
        private void CreateAircraftTypes()
        {
            CreateAircraftTypes("Boing777");
            CreateAircraftTypes("Boing666");
            CreateAircraftTypes("TU");
            CreateAircraftTypes("SU37");
            CreateAircraftTypes("Aerobus");
            CreateAircraftTypes("Boing-DreamFly");
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
        }
        private void CreateArivalAirports(string Name, string Country, string Town)
        {
            var airport = new ArivalAirports() { Name = Name, Country = Country, Town = Town };
            context.ArivalAirportsBase.Add(airport);
        }
        private void CreateBrigades()
        {
            CreateBrigades("Brigade1");
            CreateBrigades("Brigade2");
            CreateBrigades("Brigade3");

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

        }
        private void CreateFlightStatuses(string Type)
        {
            context.FlightStatusesBase.Add(new FlightStatuses()
            {
                Type = Type
            });
        }
        private void CreatePositions()
        {
            CreatePositions("HRManager", 1);
            CreatePositions("Dispetcher", 2);
            CreatePositions("Programmer", 1);
        }
        private void CreatePositions(string Name, int MedicCheckPeriod)
        {
            context.PositionsBase.Add(new Positions()
            {
                Name = Name,
                MedicCheckPeriod = MedicCheckPeriod
            });
        }
        private void CreateTechChecks()
        {
            CreateTechChecks(true);
            CreateTechChecks(false);
            CreateTechChecks(true);
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
            var a = context.AircraftsBase.Single(s => s.ID == 1) as Aircrafts;
            var f = context.FlightsBase.Single(s => s.ID == 1) as Flights;
            var b = context.FlightStatusesBase.Single(s => s.ID == 1) as FlightStatuses;
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
    }
}
