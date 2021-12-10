namespace Plumber.ControlFlowTasks
{
    using System;
    using System.Collections.Generic;

    public abstract class ControlFlowActivityBase : IControlFlowActivity
    {
        protected List<Tuple<IControlFlowActivity, FlowCondition>> Dependencies;

        public IEnumerable<Tuple<IControlFlowActivity, FlowCondition>> DependsOn => Dependencies;

        public string Name { get; }

        protected ControlFlowActivityBase() : this(Guid.NewGuid().ToString("N"))
        {
        }

        protected ControlFlowActivityBase(string name)
        {
            Dependencies = new List<Tuple<IControlFlowActivity, FlowCondition>>();
            Name = name;
        }

        public void SetAncestorDependance(IControlFlowActivity parentActivity, FlowCondition condition)
        {
            Dependencies.Add(new Tuple<IControlFlowActivity, FlowCondition>(parentActivity, condition));
        }

        public IControlFlowActivity Pipe(IControlFlowActivity parentActivity)
        {
            return Pipe(parentActivity, FlowCondition.OnSuccess());
        }

        public IControlFlowActivity Pipe(IControlFlowActivity childActivity, FlowCondition condition)
        {
            childActivity.SetAncestorDependance(this, condition);
            return childActivity;
        }
    }
}