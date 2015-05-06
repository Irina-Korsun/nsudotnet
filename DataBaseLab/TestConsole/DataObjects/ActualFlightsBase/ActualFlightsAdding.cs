using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.ActualFlightsBase
{
    class ActualFlightsAdding
    {
         private BaseContext context;
         public ActualFlightsAdding()
        {
            context = new BaseContext();
        }
         public void CreateActualFlights()
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
    }
}
