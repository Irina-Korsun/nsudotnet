using System.Net.Http;
using System.Web.Http;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace DataBaseLab.Controllers
{
    public class StubController : ApiController
    {
        private BaseContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.context = new BaseContext();
            //Drop();
            //CreateAircraftTypes();
            //CreateArivalAirports();
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Update the values of the entity that failed to save from the store 
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed); 


           // CreateArivalAirports();
           // CreateFlightCategories();
           // CreateFlightStatuses();
           // CreatePositions();
           // CreateTechChecks();
            //context.SaveChanges();
            //CreateAircrafts();
            //CreateFlights();
            //CreateActualFlights();
            //var t = context.AircraftTypesBase.Local.Single(s => s.Name == "Boing777") as AircraftTypes;
            
        }
        
    }
}
