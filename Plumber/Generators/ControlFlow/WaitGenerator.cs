namespace Plumber.Generators.ControlFlow
{
    using ControlFlowTasks;
    using Microsoft.Azure.Management.DataFactory.Models;

    public class WaitGenerator : ControlFlowGeneratorBase
    {
        public override Activity Generate(IControlFlowActivity controlActivity)
        {
            var activity = (Wait) controlActivity;

            return new WaitActivity(controlActivity.Name, activity.Seconds)
            {
                DependsOn = GenerateDependencies(activity)
            };
        }
    }
}