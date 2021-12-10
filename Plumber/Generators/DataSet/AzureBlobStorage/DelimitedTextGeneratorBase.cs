namespace Plumber.Generators.DataSet.AzureBlobStorage
{
    using Microsoft.Azure.Management.DataFactory.Models;
    using Plumber.DataSet;

    public class DelimitedTextGeneratorBase : DataSetGeneratorBase
    {
        public override DatasetResource Generate(IDataSet dataSet)
        {
            return new DatasetResource(
                new AzureBlobDataset
                {
                    LinkedServiceName = new LinkedServiceReference
                    {
                        ReferenceName = dataSet.LinkedService.Name
                    }

                    //FolderPath = new Expression { Value = "@{dataset().path}" },
                    //Parameters = new Dictionary<string, ParameterSpecification>
                    //{
                    //    { "path", new ParameterSpecification { Type = ParameterType.String } }
                }
            );
        }
    }
}