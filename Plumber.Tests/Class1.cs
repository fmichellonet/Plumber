namespace Plumber.Tests
{
    using System.Threading.Tasks;
    using ControlFlowTasks;
    using DataFlowTasks;
    using DataSet.AzureBlobStorage;
    using LinkedService;
    using Management;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;
    using NUnit.Framework;

    public class Class1
    {
        [Test]
        public async Task Deploy()
        {

            string subscriptionId = "fc41f79d-c290-44e9-832f-ad2e3d7b5545";
            string tenantID = "a90f0bba-7c46-4a5a-a5f7-7e4c5108c830";
            string applicationId = "257f2251-a611-4a0e-977e-d3c049444fd3";
            string authenticationKey = "1qzFJM_Pz-kLU3Ch2O78Frxondi7g.8B0_";
            string azureRegion = "France Central";
            string resourceGroup = "plumber";
            


            var linkedService = new AzureBlobStorage("ls_blob", @"DefaultEndpointsProtocol=https;AccountName=plumbernet;AccountKey=f9gW/RgR8LxAKA1MM2DJJRAIwzKsWmTctgODm6O63BW/u0txrUcBy7RMlyaAmc1h9KN4F4SBgoInBxWiaempzQ==;EndpointSuffix=core.windows.net");

            // creating ADF Dataflow.
            var dset = new DelimitedText<UntypedPersonAge>("UntypedPersonAge", linkedService);
            //var source = new SourceTask<UntypedPersonAge>(dset);
            //var destination = new DestinationTask<UntypedPersonAge>(dset);

            //var dataFlow = new DataFlow();
            //dataFlow.Add(source)
            //        .Pipe(destination);

            var masterPipeline = new Pipeline("master");
            var w1 = new Wait("w1", 1);
            var w2 = new Wait("w2", 2);
            var w3 = new Wait("w3", 5);

            w1.Pipe(w3);
            w2.Pipe(w3, FlowCondition.OnCompletion());

            masterPipeline.Add(w1);
            masterPipeline.Add(w2);
            masterPipeline.Add(w3);

            var factory = new DataFactory("plumber");
            factory.LinkedServices.Add(linkedService);
            factory.DataSets.Add(dset);
            factory.Pipelines.Add(masterPipeline);


            // Authenticate and create a data factory management client
            var context = new AuthenticationContext("https://login.windows.net/" + tenantID);
            ClientCredential cc = new ClientCredential(applicationId, authenticationKey);
            AuthenticationResult result = context.AcquireTokenAsync(
                "https://management.azure.com/", cc).Result;
            ServiceClientCredentials cred = new TokenCredentials(result.AccessToken);

            DataFactoryClient client = new DataFactoryClient(cred, subscriptionId);
            await client.CreateOrUpdate(factory, azureRegion, resourceGroup);
        }
    }

    public class UntypedPersonAge
    {
        public string Name { get; set; }

        public string Age { get; set; }
    }

    public class PersonAge
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}