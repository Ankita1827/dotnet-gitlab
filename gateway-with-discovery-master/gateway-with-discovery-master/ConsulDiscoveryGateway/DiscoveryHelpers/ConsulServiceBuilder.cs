using Consul;
using Ocelot.Logging;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Consul.Interfaces;

namespace ConsulDiscoveryGateway.DiscoveryHelpers
{
    public class ConsulServiceBuilder : DefaultConsulServiceBuilder
    {
        public ConsulServiceBuilder(
            Func<ConsulRegistryConfiguration> configurationFactory,
            IConsulClientFactory clientFactory, 
            IOcelotLoggerFactory loggerFactory)
        : base(null, clientFactory, loggerFactory) { }
        // I want to use the agent service IP address as the downstream hostname
        protected override string GetDownstreamHost(ServiceEntry entry, Node node) => entry.Service.Address;
    }
}
