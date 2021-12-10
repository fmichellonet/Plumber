namespace Plumber.DataSet
{
    using LinkedService;

    public interface IDataSet
    {
        string Name { get; }

        ILinkedService LinkedService { get; }
    }


    public interface IDataSet<T> : IDataSet
    {
    }
}