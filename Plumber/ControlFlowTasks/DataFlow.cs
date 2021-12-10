namespace Plumber.ControlFlowTasks
{
    using DataFlowTasks;

    public class DataFlow : ControlFlowActivityBase
    {
        public SourceTask<TOut> Add<TOut>(SourceTask<TOut> task)
        {
            return task;
        }
    }
}