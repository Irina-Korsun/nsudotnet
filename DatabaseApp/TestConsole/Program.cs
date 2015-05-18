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
using TestConsole.Sql;
using System.Text;
using System.IO;

namespace TestConsole
{
    public class Program
    {
        private BaseContext context;

        static void Main(string[] args)
        {
            var t = new Program();
            t.Start();
        }
        public void Start()
        {
            this.context = new BaseContext();
            context.Database.Delete();
            context.SaveChanges();
            Console.WriteLine("The Data Base was Dropped");
            AddDataToDataBase();
            Console.WriteLine("Data added");

            //FirstEmployeesRequests req = new FirstEmployeesRequests();
            //Console.WriteLine("Получить список и общее число всех pаботников аэpопоpта");
            //req.EmployeesListRequest();
            //Console.WriteLine();
            //Console.WriteLine("Получить список и общее число всех начальников отделов");
            //req.ChiefListRequest();
            //Console.WriteLine();
            //Console.WriteLine("Получить список и число pаботников указанного отдела");
            //Console.WriteLine("Введите название отдела из списка:");
            //req.DepartmentListRequest();
            //string department = Console.ReadLine();
            //req.EmployeesOfDepartmentRequest(department);
            //Console.ReadKey();
        }
        public void AddDataToDataBase()
        {
            var aircraftTypes = new AircraftTypesAdding();
            aircraftTypes.CreateAircraftTypes();
            var arivalAirports = new ArivalAirportsAdding();
            arivalAirports.CreateArivalAirports();
            var flightCategories = new FlightCategoriesAdding();
            flightCategories.CreateFlightCategories();
            var flightStatuses = new FlightStatusesAdding();
            flightStatuses.CreateFlightStatuses();
            var techChecks = new TechChecksAdding();
            techChecks.CreateTechChecks();
            var aircrafts = new AircraftsAdding();
            aircrafts.CreateAircrafts();
            var flights = new FlightAdding();
            flights.CreateFlights();
            var actualFlights = new ActualFlightsAdding();
            actualFlights.CreateActualFlights();
            var schedule = new ScheduleAdding();
            schedule.CreateSchedule();
            var positions = new PositionsAdding();
            positions.CreatePositions();
            var brigades = new BrigadesAdding();
            brigades.CreateBrigades();
            var departments = new DepartmentsAdding();
            departments.CreateDepartments();
            departments.AddChiefsToDepartments();
        }
        private void PrintRequestList()
        {
            string[] lines = File.ReadAllLines("req.txt");
        }

    }
}
