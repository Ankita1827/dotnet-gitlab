using ConsulDiscoveryGateway.DiscoveryHelpers;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Consul.Interfaces;

namespace ConsulDiscoveryGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                           .AddJsonFile("ocelot-discovery.json") //for gateway with discovery                                                             
                           .Build();

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOcelot(configuration)
            .AddConsul();//enabling discovery
                                                 // builder.Services.AddOcelot(configuration);
            var app = builder.Build();
            //app.MapGet("/", () => "Hello World!");
            app.UseOcelot();
            app.Run();
        }
    }
}
