namespace VatEurope
{
    public sealed class VatResponseItem
    {
        internal VatResponseItem()
        {
            IsValid = false;
        }

        internal VatResponseItem(ValidVatResponseItem data)
        {
            IsValid = true;
            Data = data;
        }

        public bool IsValid { get; }

        public ValidVatResponseItem? Data { get; }

        public override string ToString()
        {
            if (IsValid)
            {
                return Data!.ToString();
            }
            return $"INVALID";
        }
    }
}