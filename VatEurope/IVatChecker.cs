using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VatEurope.Impl;

namespace VatEurope
{
    public interface IVatChecker
    {
        Task<VatResponseItem> CheckOnline(string vatin, string requestingVatin);

        bool ValidateChecksum(string vatin);
    }
}