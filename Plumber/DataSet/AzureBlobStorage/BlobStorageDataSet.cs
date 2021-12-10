namespace Plumber.DataSet.AzureBlobStorage
{
    using LinkedService;

    public class BlobStorageDataSet : DataSetBase
    {
        public BlobStorageDataSet(string name, AzureBlobStorage linkedService) : base(name, linkedService)
        {
        }
    }
}