using System;
using System.Linq;

namespace Iban
{
    public static class IbanValidatorNL
    {
        private const string CountryCode = "NL";

        public static bool Validate(string iban)
        {
            
            return !string.IsNullOrEmpty(iban) &&
                CheckCountryCode(iban) && 
                CheckDigits(iban);
        }

        private static bool CheckDigits(string iban)
        {
            return iban.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));

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
            iban.StartsWith(CountryCode, StringComparison.InvariantCultureIgnoreCase);
    }
}