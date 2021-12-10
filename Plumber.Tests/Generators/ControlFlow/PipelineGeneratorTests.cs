namespace Plumber.Tests.Generators.ControlFlow
{
    using ControlFlowTasks;
    using FluentAssertions;
    using NUnit.Framework;
    using Plumber.Generators.ControlFlow;

    [TestFixture]
    public class PipelineGeneratorTests
    {
        [Test]
        public void HasGenerator()
        {
            var pipe = new Pipeline("my_pipeline");

            pipe.GetGenerator().Should().NotBeNull();
        }

        [Test]
        public void CanGenerate()
        {
            var pipe = new Pipeline("my_pipeline");

            pipe.Generate().Should().NotBeNull();
        }
    }
}