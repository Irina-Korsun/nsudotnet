using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.ArivalAirportsBase
{
    class ArivalAirportsAdding
    {
         private BaseContext context;
         public ArivalAirportsAdding()
         {
            context = new BaseContext();
         }
         public void CreateArivalAirports()
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

    }
}
