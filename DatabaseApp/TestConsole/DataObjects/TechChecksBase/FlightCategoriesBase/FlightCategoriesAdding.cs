using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;


namespace TestConsole.DataObjects.FlightCategoriesBase
{
    class FlightCategoriesAdding
    {
        private BaseContext context;
        public FlightCategoriesAdding()
        {
            context = new BaseContext();
        }
        public void CreateFlightCategories()
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
    }
}
