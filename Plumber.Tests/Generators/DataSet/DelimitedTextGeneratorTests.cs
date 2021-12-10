namespace Plumber.Tests.Generators.DataSet
{
    using FluentAssertions;
    using NUnit.Framework;
    using Plumber.DataSet.AzureBlobStorage;
    using Plumber.Generators.DataSet;
    using Plumber.LinkedService;

    [TestFixture]
    public class DelimitedTextGeneratorTests
    {
        [Test]
        public void HasGenerator()
        {
            var ds = new DelimitedText("my_ds", new AzureBlobStorage("my_ls", ""));

            ds.GetGenerator().Should().NotBeNull();
        }

        [Test]
        public void CanGenerate()
        {
            var ds = new DelimitedText("my_ds", new AzureBlobStorage("my_ls", ""));

            ds.Generate().Should().NotBeNull();
        }
    }
}