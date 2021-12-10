namespace Plumber.LinkedService
{
    using System;
    using Generators.LinkedService;

    [LinkedServiceGenerator(typeof(AzureBlobStorageGeneratorBase))]
    public class AzureBlobStorage : ILinkedService
    {
        public string Name { get; }
        public string ConnectionString { get; }

        public AzureBlobStorage(string name, string connectionString)
        {
            Name = name;
            ConnectionString = connectionString;
        }

        public AzureBlobStorage(string connectionString) : this(Guid.NewGuid().ToString("N"), connectionString)
        {
        }
    }
}