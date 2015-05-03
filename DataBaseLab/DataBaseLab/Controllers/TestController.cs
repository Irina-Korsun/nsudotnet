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
      
    }
}
