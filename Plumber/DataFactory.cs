namespace Plumber
{
    using System.Collections.Generic;
    using ControlFlowTasks;
    using DataSet;
    using LinkedService;

    public class DataFactory
    {
        public string Name { get; }

        public IList<IDataSet> DataSets { get; }

        public IList<Pipeline> Pipelines { get; }
        public IList<ILinkedService> LinkedServices { get; set; }

        public DataFactory(string name)
        {
            Name = name;
            DataSets = new List<IDataSet>();
            LinkedServices = new List<ILinkedService>();
            Pipelines = new List<Pipeline>();
        }
    }
}