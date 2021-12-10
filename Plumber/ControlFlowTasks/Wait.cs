namespace Plumber.ControlFlowTasks
{
    using System;
    using Generators.ControlFlow;

    [ControlFlowGenerator(typeof(WaitGenerator))]
    public class Wait : ControlFlowActivityBase
    {
        public int Seconds { get; }
        
        public Wait(int seconds) : this(Guid.NewGuid().ToString("N"), seconds) {}

        public Wait(string name, int seconds) : base(name)
        {
            Seconds = seconds;
        }
    }
}