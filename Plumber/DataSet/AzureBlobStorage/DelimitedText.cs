namespace Plumber.DataSet.AzureBlobStorage
{
    using Generators.DataSet;
    using Generators.DataSet.AzureBlobStorage;
    using LinkedService;


    [DataSetGenerator(typeof(DelimitedTextGeneratorBase))]
    public class DelimitedText : DataSetBase
    {
        public DelimitedText(string name, AzureBlobStorage linkedService): base(name, linkedService)
        {
        }
    }

    public class DelimitedText<T> : DelimitedText, IDataSet<T>
    {

        public DelimitedText(string name, AzureBlobStorage linkedService) : base(name, linkedService)
        {
        }
    }
}