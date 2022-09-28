using System;
using System.Linq;

namespace Iban
{
    internal class IbanValidatorNL : IIbanValidator
    {
        private const string CountryCode = "NL";
        private readonly IBankCodeProvider _provider;

        public IbanValidatorNL(IBankCodeProvider provider) => 
            _provider = provider;

        public bool Validate(string iban) =>
            CheckCountryCode(iban) &&
            iban.CheckDigits() &&
            CheckBankCode(iban);

        private bool CheckBankCode(string iban) =>
            _provider.BankCodes().Contains(iban.Substring(4, 4));

        private static bool CheckCountryCode(string iban) =>
            iban.StartsWith(CountryCode);
    }
}