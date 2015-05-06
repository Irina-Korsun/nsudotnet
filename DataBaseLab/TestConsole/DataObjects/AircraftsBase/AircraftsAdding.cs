using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.AircraftsBase
{
    class AircraftsAdding
    {
        private BaseContext context;
        public AircraftsAdding()
        {
            context = new BaseContext();
        }
        public void CreateAircrafts()
        {
            CreateAircrafts("Boing777", 1);
            CreateAircrafts("Boing666", 2);
            CreateAircrafts("TU", 3);
            CreateAircrafts("SU37", 4);
            context.SaveChanges();
        }
        private void CreateAircrafts(string AircraftType, long ID)
        {
            var t = context.AircraftTypesBase.Single(s => s.Name == AircraftType) as AircraftTypes;
            var c = context.TechChecksBase.Single(s => s.ID == ID) as TechChecks;
            context.AircraftsBase.Add(new Aircrafts()
            {
                AircraftType = t,
                TechCheck = c,
                NumberOfFlights = 0
            });
        }
    }

}
