namespace VatEurope
{
    public interface IChecksum
    {
        bool IsValidChecksum(string vat);
    }
}