using System.Threading.Tasks;
using VatEurope.VIES;

namespace VatEurope.Impl
{
    internal sealed class VatCheckerImpl : IVatChecker
    {
        public bool IsValidChecksum(string vatin)
        {
            if (string.IsNullOrEmpty(vatin))
            {
                return false;
            }

            var clearedVatin = RemoveEmptyPieces(vatin);

            if (clearedVatin.Length < 3)
            {
                return false;
            }

            var country = CountryEnum.GetByCode(vatin.Substring(0, 2));

            return country.IsValidChecksum(vatin);
        }

        public async Task<VatResponseItem> CheckOnline(string vatin, string requestingVatin)
        {
            #region CHECKING FOR ERROR

            if (!IsValidChecksum(vatin))
            {
                return new VatResponseItem();
            }

            #endregion CHECKING FOR ERROR

            using (var client = new checkVatPortTypeClient())
            {
                var channel = client.ChannelFactory.CreateChannel();

                var response = await channel.checkVatAsync(new checkVatRequest
                {
                    countryCode = vatin.Substring(0, 2),
                    vatNumber = vatin.Substring(2)
                });

                if (response is not null && response.valid)
                {
                    return new VatResponseItem(new ValidVatResponseItem(
                        response.countryCode,
                        response.vatNumber,
                        response.requestDate,
                        response.name,
                        response.address
                        ));
                }
            }

            return new VatResponseItem();
        }

        private static string RemoveEmptyPieces(string input)
        {
            return input.Replace(" ", "") //trim is maybe not enought if someone formats the vat-number with space in between
                .Replace("\n", "")
                .Replace("\r", "");
        }
    }
}