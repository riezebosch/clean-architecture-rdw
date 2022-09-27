using System;
using System.Linq;

namespace Iban
{
    public class IbanValidatorNL
    {
        private const string CountryCode = "NL";
        private readonly IBankCodeProvider _provider;

        public IbanValidatorNL(IBankCodeProvider provider)
        {
            _provider = provider;
        }

        public bool Validate(string iban)
        {
            if (iban is null)
            {
                throw new ArgumentNullException(nameof(iban));
            }

            iban = Sanitize(iban);
            return !string.IsNullOrEmpty(iban) &&
                CheckCountryCode(iban) &&
                CheckDigits(iban) &&
                CheckBankCode(iban);
        }

        private bool CheckBankCode(string iban) => 
            _provider.BankCodes().Contains(iban.Substring(4, 4));

        private static string Sanitize(string iban) =>
            iban.Replace(" ", "").ToUpper();

        private static bool CheckDigits(string iban)
        {
            return iban.All(c => char.IsLetterOrDigit(c));

            //foreach (var c in iban)
            //{
            //    if (!char.IsLetterOrDigit(c) && c != ' ')
            //    {
            //        return false;
            //    }
            //}

            //return true;
        }

        private static bool CheckCountryCode(string iban) =>
            iban.StartsWith(CountryCode);
    }
}