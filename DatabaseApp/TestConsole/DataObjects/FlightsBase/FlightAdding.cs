using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.FlightsBase
{
    class FlightAdding
    {
          private BaseContext context;
          public FlightAdding()
        {
            context = new BaseContext();
        }
          public void CreateFlights()
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
    }
}
