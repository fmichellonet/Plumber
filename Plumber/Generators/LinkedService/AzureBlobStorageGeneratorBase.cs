namespace Plumber.Generators.LinkedService
{
    using Microsoft.Azure.Management.DataFactory.Models;
    using Plumber.LinkedService;

    public class AzureBlobStorageGeneratorBase : LinkedServiceGeneratorBase
    {
        public override LinkedServiceResource Generate(ILinkedService linkedService)
        {
            var typedLS = (AzureBlobStorage) linkedService;

            return new LinkedServiceResource(
                new AzureStorageLinkedService
                {
                    ConnectionString = new SecureString(typedLS.ConnectionString)
                }
            );
        }
    }
}