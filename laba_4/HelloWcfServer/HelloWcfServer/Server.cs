using System;
using System.ServiceModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace HelloWcfServer
{
    class Server{
   
        static void Main()
        {
            Console.Title = "Server";
            Uri address = new Uri("http://localhost:4000/IContract");
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IContract);
            ServiceHost host = new ServiceHost(typeof(Service));
            host.AddServiceEndpoint(contract, binding, address);
            host.Open();
            Console.WriteLine("ready");
            Console.ReadKey();
        }
    }
}