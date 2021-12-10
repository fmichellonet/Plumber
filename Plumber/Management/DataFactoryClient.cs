namespace Plumber.Management
{
    using System.Threading.Tasks;
    using Generators.ControlFlow;
    using Generators.DataSet;
    using Generators.LinkedService;
    using Microsoft.Azure.Management.DataFactory;
    using Microsoft.Azure.Management.DataFactory.Models;
    using Microsoft.Rest;

    public class DataFactoryClient
    {
        private readonly DataFactoryManagementClient _client;

        public DataFactoryClient(ServiceClientCredentials credentials, string subscriptionId)
        {
            _client = new DataFactoryManagementClient(credentials){SubscriptionId = subscriptionId};
        }


        public async Task CreateOrUpdate(DataFactory factory, string azureRegion, string resourceGroup)
        {
            var dataFactory = new Factory
            {
                Location = azureRegion,
                Identity = new FactoryIdentity()
            };
            await _client.Factories.CreateOrUpdateAsync(resourceGroup, factory.Name, dataFactory);

            foreach (var ls in factory.LinkedServices)
            {
                var resource = ls.Generate();
                await _client.LinkedServices.CreateOrUpdateAsync(resourceGroup, factory.Name, ls.Name, resource);
            }

            foreach (var ds in factory.DataSets)
            {
                var resource = ds.Generate();
                await _client.Datasets.CreateOrUpdateAsync(resourceGroup, factory.Name, ds.Name, resource);
            }

            foreach (var pipeline in factory.Pipelines)
            {
                var resource = pipeline.Generate();
                await _client.Pipelines.CreateOrUpdateAsync(resourceGroup, factory.Name, pipeline.Name, resource);
            }
        }
    }
}