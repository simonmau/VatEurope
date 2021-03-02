using System.Threading.Tasks;

namespace VatEurope
{
    public interface IVatChecker : IChecksum
    {
        Task<VatResponseItem> CheckOnline(string vatin, string requestingVatin);
    }
}