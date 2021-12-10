namespace Plumber.Generators.ControlFlow
{
    using System;

    public class PipelineGeneratorAttribute : Attribute
    {
        public Type GeneratorType { get; }

        public PipelineGeneratorAttribute(Type type)
        {
            if (!typeof(PipelineGenerator).IsAssignableFrom(type))
            {
                throw new InvalidOperationException($@"{type} does not inherit from {typeof(PipelineGenerator)}");
            }

            GeneratorType = type;
        }

        public PipelineGenerator GetGenerator()
        {
            return (PipelineGenerator) Activator.CreateInstance(GeneratorType);
        }
    }
}