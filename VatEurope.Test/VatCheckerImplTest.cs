using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace VatEurope.Test
{
    [TestFixture]
    public sealed class VatCheckerImplTest
    {
        private IVatChecker vatChecker;

        [SetUp]
        public void CreateImpl()
        {
            vatChecker = new Impl.VatCheckerImpl();
        }

        [TestCase("ATU73952234")]
        public async Task TestValidVat(string validVat)
        {
            var result = await vatChecker.CheckOnline(validVat, validVat);

            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();

            result.Data.Should().NotBeNull();
            result.Data!.Name.Should().Be("Mauracher Simon");
        }
    }
}