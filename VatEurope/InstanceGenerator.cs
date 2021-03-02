namespace VatEurope
{
    public static class InstanceGenerator
    {
        public static IVatChecker GetVatCheckerInstance() => new Impl.VatCheckerImpl();
    }
}