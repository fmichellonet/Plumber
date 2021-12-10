namespace Plumber.Tests.Generators.LinkedService
{
    using FluentAssertions;
    using NUnit.Framework;
    using Plumber.Generators.LinkedService;
    using Plumber.LinkedService;

    [TestFixture]
    public class AzureBlobStorageTests
    {
        [Test]
        public void HasGenerator()
        {
            var ls = new AzureBlobStorage("my_ls", "my connection string");

            ls.GetGenerator().Should().NotBeNull();
        }

        [Test]
        public void CanGenerate()
        {
            var ls = new AzureBlobStorage("my_ls", "my connection string");

            ls.Generate().Should().NotBeNull();
        }
    }
}