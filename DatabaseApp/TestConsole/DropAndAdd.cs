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
    
    public class DropAndAdd
    {
        private BaseContext context;
        public DropAndAdd()
        {
            this.context = new BaseContext();
            context.Database.Delete();
            context.SaveChanges();
        }
    }
}
