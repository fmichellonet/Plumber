namespace Plumber.Generators.DataSet
{
    using System;

    public class DataSetGeneratorAttribute : Attribute
    {
        public Type GeneratorType { get; }

        public DataSetGeneratorAttribute(Type type)
        {
            if (!typeof(DataSetGeneratorBase).IsAssignableFrom(type))
                throw new InvalidOperationException($@"{type} does not inherit from {typeof(DataSetGeneratorBase)}");

            GeneratorType = type;
        }

        public DataSetGeneratorBase GetGenerator()
        {
            return (DataSetGeneratorBase)Activator.CreateInstance(GeneratorType);
        }
    }
}