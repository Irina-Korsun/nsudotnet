using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using DataBaseLab.DataObjects;
using DataBaseLab.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using DataBaseLab.MainSystem;

namespace DataBaseLab
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new ContexBaseInitializer<BaseContext>());

        }
    }

    public class ContexBaseInitializer<T> : DropCreateDatabaseIfModelChanges<T> where T : DbContext, new()
    {
        protected override void Seed(T context)
        {
            base.Seed(context);
        }
    }
}

