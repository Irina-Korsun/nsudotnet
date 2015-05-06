using System;
using System.Linq;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using TestConsole.DataObjects.AircraftTypesBase;
using TestConsole.DataObjects.ArivalAirportsBase;
using TestConsole.DataObjects.FlightCategoriesBase;
using TestConsole.DataObjects.FlightStatusesBase;
using TestConsole.DataObjects.TechChecksBase;
using TestConsole.DataObjects.AircraftsBase;
using TestConsole.DataObjects.FlightsBase;
using TestConsole.DataObjects.ActualFlightsBase;
using TestConsole.DataObjects.ScheduleBase;
using TestConsole.DataObjects.PositionsBase;
using TestConsole.DataObjects.BrigadesBase;
using TestConsole.DataObjects.DepartmentsBase;
using TestConsole.DataObjects.EmployeesAndChildsBase;



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
            var a = new AircraftTypesAdding();
            a.CreateAircraftTypes();
            var b = new ArivalAirportsAdding();
            b.CreateArivalAirports();
            var c = new FlightCategoriesAdding();
            c.CreateFlightCategories();
            var d = new FlightStatusesAdding();
            d.CreateFlightStatuses();
            var f = new TechChecksAdding();
            f.CreateTechChecks();
            var t = new AircraftsAdding();
            t.CreateAircrafts();
            var q = new FlightAdding();
            q.CreateFlights();
            var y = new ActualFlightsAdding();
            y.CreateActualFlights();
            var o = new ScheduleAdding();
            o.CreateSchedule();
            var x = new PositionsAdding();
            x.CreatePositions();
            var z = new BrigadesAdding();
            z.CreateBrigades();
            var w = new DepartmentsAdding();
            w.CreateDepartments();
            var j = new EmployeesAndChildrensAdding();
            j.CreateEmployeesAndChildrens();
        }
    }
}
