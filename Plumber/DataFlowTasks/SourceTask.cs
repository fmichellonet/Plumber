namespace Plumber.DataFlowTasks
{
    using DataSet;

    public class SourceTask<T>
    {
        private readonly IDataSet<T> _dataset;

        public SourceTask(IDataSet<T> dataset)
        {
            _dataset = dataset;
        }

        public void Pipe(DestinationTask<T> destination)
        {

        }
    }
}