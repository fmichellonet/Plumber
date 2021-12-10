namespace Plumber.Generators.LinkedService
{
    using System;

    public class LinkedServiceGeneratorAttribute : Attribute
    {
        public Type GeneratorType { get; }

        public LinkedServiceGeneratorAttribute(Type type)
        {
            if (!typeof(LinkedServiceGeneratorBase).IsAssignableFrom(type))
                throw new InvalidOperationException($@"{type} does not inherit from {typeof(LinkedServiceGeneratorBase)}");

            GeneratorType = type;
        }

        public LinkedServiceGeneratorBase GetGenerator()
        {
            return (LinkedServiceGeneratorBase)Activator.CreateInstance(GeneratorType);
        }
    }
}