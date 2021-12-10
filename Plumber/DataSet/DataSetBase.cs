namespace Plumber.DataSet
{
    using System;
    using LinkedService;

    public abstract class DataSetBase : IDataSet

    {
        public string Name { get; }

        public ILinkedService LinkedService { get; }

        protected DataSetBase(string name, LinkedService.AzureBlobStorage linkedService)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (linkedService is null)
            {
                throw new ArgumentNullException(nameof(linkedService));
            }

            Name = name;
            LinkedService = linkedService;
        }
    }
}