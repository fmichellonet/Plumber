namespace Plumber.Generators.ControlFlow
{
    using System.Linq;
    using Microsoft.Azure.Management.DataFactory.Models;
    using Pipeline = ControlFlowTasks.Pipeline;

    public class PipelineGenerator
    {
        public PipelineResource Generate(Pipeline pipeline)
        {
            return new PipelineResource
            {
                Activities = pipeline.ChildrenActivities.Select(x => x.Generate()).ToList()
            };
        }
    }
}