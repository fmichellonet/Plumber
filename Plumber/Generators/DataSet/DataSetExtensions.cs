namespace Plumber.Generators.DataSet
{
    using System.Reflection;
    using Generators;
    using Microsoft.Azure.Management.DataFactory.Models;
    using Plumber.DataSet;

    public static class DataSetExtensions
    {
        public static DataSetGeneratorBase GetGenerator(this IDataSet dataSet)
        {
            var genAttr = dataSet.GetType().GetCustomAttribute<DataSetGeneratorAttribute>();
            return genAttr?.GetGenerator();
        }

        public static DatasetResource Generate(this IDataSet dataSet)
        {
            var generator = dataSet.GetGenerator();
            return generator?.Generate(dataSet);
        }
    }
}