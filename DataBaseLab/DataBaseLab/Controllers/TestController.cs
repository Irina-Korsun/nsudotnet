using System.Net.Http;
using System.Web.Http;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;

namespace DataBaseLab.Controllers
{
    public class TestController : ApiController
    {
        private BaseContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.context = new BaseContext();
        }
        [HttpGet]
        public List<Childs> GetChilds()
        {
            var child = new Childs() { Name = "Irina" };
            context.ChildrenBase.Add(child);
           /* var rest = new Place() { Name = "SHum" };
            context.RestaurantsBase.Add(rest);
            var stub = new Review() { ReviewText = "First", Rating = Rate.VeryGood };
            stub.User = user;
            stub.Restaurant = rest;
            context.ReviewBase.Add(stub);
            stub = new Review() { ReviewText = "Second", Rating = Rate.VeryGood };
            stub.User = user;
            stub.Restaurant = rest;
            context.ReviewBase.Add(stub);*/
            context.SaveChanges();
            return context.ChildrenBase.ToList<Childs>();
        }
    }
}
