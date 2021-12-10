namespace Plumber
{
    using Microsoft.Azure.Management.DataFactory.Models;

    public class FlowCondition
    {
        private readonly string _condition;

        private FlowCondition(string condition)
        {
            _condition = condition;
        }

        public override string ToString() => _condition;

        public static FlowCondition OnSuccess() { return new FlowCondition(DependencyCondition.Succeeded);}

        public static FlowCondition OnCompletion() { return new FlowCondition(DependencyCondition.Completed); }

        public static FlowCondition OnFailure() { return new FlowCondition(DependencyCondition.Failed); }

        public static FlowCondition OnSkip() { return new FlowCondition(DependencyCondition.Skipped); }
    }
}