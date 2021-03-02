# VatEurope - a C# lib to check VAT-Numbers in Europe (with VIES online validation)

[![NuGet version (VatEurope)](https://img.shields.io/nuget/v/VatEurope.svg?style=flat-square)](https://www.nuget.org/packages/VatEurope/)

This library checks the checksum from every EU state locally, if this test is passed a request is send to the VIES system to check if a company exists.
When possible the company name and the address is returned.

## Usage

### You already know the country (only checksum)

```c#
VatEurope.CountryEnum.Austria.IsValidChecksum("ATU12345678");
```

### You do not know the country (only checksum)

```c#
//assuming you dont have a DI framework
IVatChecker instance = VatEurope.InstanceGenerator.GetVatCheckerInstance(); 

bool isValid = instance.IsValidChecksum("ATU12345678");
```

### Validate the VAT number online

```c#
//assuming you dont have a DI framework
IVatChecker instance = VatEurope.InstanceGenerator.GetVatCheckerInstance(); 

VatResponseItem response = await instance.CheckOnline("ATU12345678");

//respone cannot be null
if(response.IsValid)
{
    Console.WriteLine($"RESULT: {response.CountryCode}{VatNumber}");
    Console.WriteLine(response.Name);
    Console.WriteLine(response.Address);

    ////PRINTS: 
    //RESULT: ATU12345678
    //SOME COMPANY
    //RANDOM STREET 1
    //1234 RANDOM CITY
}
else
{
    //respose.Data is null
}
```
