using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.ScheduleBase
{
    class ScheduleAdding
    {
          private BaseContext context;
          public ScheduleAdding()
        {
            context = new BaseContext();
        }
          public void CreateSchedule()
          {
              CreateSchedule(1, 1, 2000);
              CreateSchedule(1, 2, 3000);
              CreateSchedule(2, 3, 100);
              CreateSchedule(2, 4, 100);
              context.SaveChanges();
          }
          private void CreateSchedule(int AircraftTypeID, int FlightID, int Price)
          {
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
    }
}
