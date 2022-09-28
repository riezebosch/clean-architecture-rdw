using System.Linq;

namespace Iban
{
    internal static class IbanHelpers
    {
        public static bool CheckDigits(this string input)
        {
            return input.All(c => char.IsLetterOrDigit(c));

            //foreach (var c in iban)
            //{
            //    if (!char.IsLetterOrDigit(c) && c != ' ')
            //    {
            //        return false;
            //    }
            //}

            //return true;
        }
    }
}