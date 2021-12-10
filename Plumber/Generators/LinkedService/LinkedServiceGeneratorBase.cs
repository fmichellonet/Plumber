namespace Plumber.Generators.LinkedService
{
    using Microsoft.Azure.Management.DataFactory.Models;
    using Plumber.LinkedService;

    public abstract class LinkedServiceGeneratorBase
    {
        public abstract LinkedServiceResource Generate(ILinkedService linkedService);
    }
}