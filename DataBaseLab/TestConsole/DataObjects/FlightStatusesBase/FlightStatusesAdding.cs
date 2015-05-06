using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.FlightStatusesBase
{
    class FlightStatusesAdding
    {
        private BaseContext context;
        public FlightStatusesAdding()
        {
            context = new BaseContext();
        }
        public void CreateFlightStatuses()
        {
            CreateFlightStatuses("Canceled");
            CreateFlightStatuses("Ready");
            CreateFlightStatuses("Delayed");
            CreateFlightStatuses("Boarding");
            context.SaveChanges();

        }
        private void CreateFlightStatuses(string Type)
        {
            context.FlightStatusesBase.Add(new FlightStatuses()
            {
                Type = Type
            });
        }
    }
}
