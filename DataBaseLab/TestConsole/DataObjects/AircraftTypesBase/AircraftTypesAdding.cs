using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.AircraftTypesBase
{
    class AircraftTypesAdding
    {
        private BaseContext context;
        public AircraftTypesAdding()
        {
            context = new BaseContext();
        }

        public void CreateAircraftTypes()
        {
            CreateAircraftTypes("Boing777");
            CreateAircraftTypes("Boing666");
            CreateAircraftTypes("TU");
            CreateAircraftTypes("SU37");
            CreateAircraftTypes("Aerobus");
            CreateAircraftTypes("Boing-DreamFly");
            context.SaveChanges();
        }
        private void CreateAircraftTypes(string Name)
        {
            var type = new AircraftTypes() { Name = Name };
            context.AircraftTypesBase.Add(type);
        }
    }
}
