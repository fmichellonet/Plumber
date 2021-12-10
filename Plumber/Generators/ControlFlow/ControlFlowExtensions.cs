namespace Plumber.Generators.ControlFlow
{
    using System.Reflection;
    using ControlFlowTasks;
    using Microsoft.Azure.Management.DataFactory.Models;

    public static class ControlFlowExtensions
    {
        public static ControlFlowGeneratorBase GetGenerator(this IControlFlowActivity controlFlow)
        {
            var genAttr = controlFlow.GetType().GetCustomAttribute<ControlFlowGeneratorAttribute>();
            return genAttr?.GetGenerator();
        }

        public static Activity Generate(this IControlFlowActivity controlFlow)
        {
            var generator = controlFlow.GetGenerator();
            return generator?.Generate(controlFlow);
        }
    }
}