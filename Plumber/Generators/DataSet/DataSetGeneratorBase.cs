namespace Plumber.Generators.DataSet
{
    using Microsoft.Azure.Management.DataFactory.Models;
    using Plumber.DataSet;

    public abstract class DataSetGeneratorBase
    {
        public abstract DatasetResource Generate(IDataSet dataSet);
    }
}