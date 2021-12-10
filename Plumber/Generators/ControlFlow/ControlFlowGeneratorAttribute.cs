namespace Plumber.Generators.ControlFlow
{
    using System;

    public class ControlFlowGeneratorAttribute : Attribute
    {
        public Type GeneratorType { get; }

        public ControlFlowGeneratorAttribute(Type type)
        {
            if (!typeof(ControlFlowGeneratorBase).IsAssignableFrom(type))
            {
                throw new InvalidOperationException($@"{type} does not inherit from {typeof(ControlFlowGeneratorBase)}");
            }

            GeneratorType = type;
        }

        public ControlFlowGeneratorBase GetGenerator()
        {
            return (ControlFlowGeneratorBase)Activator.CreateInstance(GeneratorType);
        }
    }
}