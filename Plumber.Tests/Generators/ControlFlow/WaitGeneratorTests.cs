namespace Plumber.Tests.Generators.ControlFlow
{
    using ControlFlowTasks;
    using FluentAssertions;
    using NUnit.Framework;
    using Plumber.Generators.ControlFlow;

    [TestFixture]
    public class WaitGeneratorTests
    {
        [Test]
        public void HasGenerator()
        {
            var activity = new Wait("w1", 2);

            activity.GetGenerator().Should().NotBeNull();
        }

        [Test]
        public void CanGenerate()
        {
            var activity = new Wait("w1", 2);

            activity.Generate().Should().NotBeNull();
        }
    }
}