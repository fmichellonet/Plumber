namespace Plumber.ControlFlowTasks
{
    using System;
    using System.Collections.Generic;

    public interface IControlFlowActivity
    {
        IEnumerable<Tuple<IControlFlowActivity, FlowCondition>> DependsOn { get; }

        string Name { get;}

        void SetAncestorDependance(IControlFlowActivity parentActivity, FlowCondition condition);

        IControlFlowActivity Pipe(IControlFlowActivity activity);

        IControlFlowActivity Pipe(IControlFlowActivity activity, FlowCondition condition);
    }
}