namespace Plumber.Generators.ControlFlow
{
    using System.Reflection;
    using Microsoft.Azure.Management.DataFactory.Models;
    using Pipeline = ControlFlowTasks.Pipeline;

    public static class PipelineExtensions
    {
        public static PipelineGenerator GetGenerator(this Pipeline pipeline)
        {
            var genAttr = pipeline.GetType().GetCustomAttribute<PipelineGeneratorAttribute>();
            return genAttr?.GetGenerator();
        }

        public static PipelineResource Generate(this Pipeline pipeline)
        {
            var generator = pipeline.GetGenerator();
            return generator?.Generate(pipeline);
        }
    }
}
