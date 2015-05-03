using System.Net.Http;
using System.Web.Http;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;


namespace DataBaseLab.Controllers
{
    public class StubController : ApiController
    {
        private BaseContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.context = new BaseContext();
        }
        [HttpGet]
        public bool Get()
        {
            CreateAircraftTypes();
            CreateArivalAirports();
            CreateFlightCategories();
            context.SaveChanges();
            return true;
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
            context.AircraftTypesBase.Add(new AircfaftTypes()
            {
                Name = Name
            });
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
            context.ArivalAirportsBase.Add(new ArivalAirports()
            {
                Name = Name,
                Country = Country,
                Town = Town
            });
        }
        private void CreateBrigades()
        {
            CreateBrigades("Brigade1");

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
            CreateFlightCategories("Canceled");
            CreateFlightCategories("Ready");

        }
        private void CreateFlightCategories(string Type)
        {
            context.FlightCategoriesBase.Add(new FlightCategories()
            {
                Type = Type
            });
        }

        private void CreatePositions()
        {
            CreatePosition("HRManager",1);
            CreatePosition("Dispetcher",2);
            CreatePosition("Programmer", 1);
        }
        private void CreatePosition(string Name, int MedicCheckPeriod)
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
            CreateAircrafts("Boing777",1);
            CreateAircrafts("Boing666", 2);
            CreateAircrafts("TU",3);
        }
        private void CreateAircrafts(string AircraftType, long ID)
        {
            var t = context.AircraftTypesBase.Single(s => s.Name == AircraftType) as AircfaftTypes;
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
            CreateFlights("Canceled", "Domodedovo");
            CreateFlights("Ready", "Domodedovo");
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
    }
}
