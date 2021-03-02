using System.Threading.Tasks;

namespace VatEurope
{
    public interface IVatChecker
    {
        Task<VatResponseItem> CheckOnline(string vatin, string requestingVatin);

        bool ValidateChecksum(string vatin);
    }
}