namespace Plumber.ControlFlowTasks
{
    using System;
    using System.Collections.Generic;
    using Generators.ControlFlow;

    [PipelineGenerator(typeof(PipelineGenerator))]
    public class Pipeline : ControlFlowActivityBase
    {

        private readonly IList<IControlFlowActivity> _children;

        public IEnumerable<IControlFlowActivity> ChildrenActivities => _children;

        public Pipeline(): this(Guid.NewGuid().ToString("N"))
        {

        }

        public Pipeline(string name) : base(name)
        {
            _children = new List<IControlFlowActivity>();
        }

        
        public IControlFlowActivity Add(IControlFlowActivity childControlFlow)
        {
            _children.Add(childControlFlow);
            return childControlFlow;
        }
    }
}