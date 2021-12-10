namespace Plumber.Generators.LinkedService
{
    using System.Reflection;
    using Microsoft.Azure.Management.DataFactory.Models;
    using Plumber.LinkedService;

    public static class LinkedServiceExtensions
    {
        public static LinkedServiceGeneratorBase GetGenerator(this ILinkedService linkedService)
        {
            var genAttr = linkedService.GetType().GetCustomAttribute<LinkedServiceGeneratorAttribute>();
            return genAttr?.GetGenerator();
        }

        public static LinkedServiceResource Generate(this ILinkedService dataSet)
        {
            var generator = dataSet.GetGenerator();
            return generator?.Generate(dataSet);
        }
    }
}