namespace Plumber.DataFlowTasks
{
    using DataSet;

    public class DestinationTask<T>
    {
        private readonly IDataSet<T> _dataset;

        public DestinationTask(IDataSet<T> dataset)
        {
            _dataset = dataset;
        }
    }
}