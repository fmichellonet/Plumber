namespace Plumber.Generators.ControlFlow
{
    using System.Collections.Generic;
    using System.Linq;
    using ControlFlowTasks;
    using Microsoft.Azure.Management.DataFactory.Models;

    public abstract class ControlFlowGeneratorBase
    {
        public abstract Activity Generate(IControlFlowActivity controlActivity);

        public IList<ActivityDependency> GenerateDependencies(IControlFlowActivity controlActivity)
        {
            return controlActivity.DependsOn.Select(x =>
                new ActivityDependency(x.Item1.Name, new[] { x.Item2.ToString() }))
                                  .ToList();
        }
    }
}