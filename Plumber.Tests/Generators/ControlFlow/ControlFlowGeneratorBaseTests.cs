namespace Plumber.Tests.Generators.ControlFlow
{
    using System.Linq;
    using ControlFlowTasks;
    using FluentAssertions;
    using Microsoft.Azure.Management.DataFactory.Models;
    using NSubstitute;
    using NUnit.Framework;
    using Plumber.Generators.ControlFlow;

    [TestFixture]
    public class ControlFlowGeneratorBaseTests
    {

        [Test]
        public void SuccessDependencyIsGenerated()
        {
            var parent = Substitute.For<ControlFlowActivityBase>();
            var child = Substitute.For<ControlFlowActivityBase>();
            var generator = Substitute.For<ControlFlowGeneratorBase>();

            parent.Pipe(child, FlowCondition.OnSuccess());
            
            string[] expected = { DependencyCondition.Succeeded };

            generator.GenerateDependencies(child)
                     .First()
                     .DependencyConditions
                     .Should()
                     .BeEquivalentTo(expected);
        }

        [Test]
        public void CompletedDependencyIsGenerated()
        {
            var parent = Substitute.For<ControlFlowActivityBase>();
            var child = Substitute.For<ControlFlowActivityBase>();
            var generator = Substitute.For<ControlFlowGeneratorBase>();

            parent.Pipe(child, FlowCondition.OnCompletion());

            string[] expected = { DependencyCondition.Completed };

            generator.GenerateDependencies(child)
                     .First()
                     .DependencyConditions
                     .Should()
                     .BeEquivalentTo(expected);
        }

        [Test]
        public void FailedDependencyIsGenerated()
        {
            var parent = Substitute.For<ControlFlowActivityBase>();
            var child = Substitute.For<ControlFlowActivityBase>();
            var generator = Substitute.For<ControlFlowGeneratorBase>();

            parent.Pipe(child, FlowCondition.OnFailure());

            string[] expected = { DependencyCondition.Failed };

            generator.GenerateDependencies(child)
                     .First()
                     .DependencyConditions
                     .Should()
                     .BeEquivalentTo(expected);
        }

        [Test]
        public void SkippedDependencyIsGenerated()
        {
            var parent = Substitute.For<ControlFlowActivityBase>();
            var child = Substitute.For<ControlFlowActivityBase>();
            var generator = Substitute.For<ControlFlowGeneratorBase>();

            parent.Pipe(child, FlowCondition.OnSkip());

            string[] expected = { DependencyCondition.Skipped };

            generator.GenerateDependencies(child)
                     .First()
                     .DependencyConditions
                     .Should()
                     .BeEquivalentTo(expected);
        }
        
    }
}