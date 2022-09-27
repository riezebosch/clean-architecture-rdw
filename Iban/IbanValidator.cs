using System;
using System.Collections;
using System.Collections.Generic;

namespace Iban.Tests
{
    public class IbanValidator
    {
        IDictionary<string, IIbanValidator> _validators = new Dictionary<string, IIbanValidator>();

        public IbanValidator(IBankCodeProvider provider)
        {
            _validators["NL"] = new IbanValidatorNL(provider);
            _validators["BE"] = new IbanValidatorBE();
        }

        public bool Validate(string iban)
        {
            if (iban is null)
            {
                throw new ArgumentNullException(nameof(iban));
            }

            iban = Sanitize(iban);
            return !string.IsNullOrEmpty(iban) && _validators.TryGetValue(iban.Substring(0, 2), out var validator) ? validator.Validate(iban) : false;
        }

        private static string Sanitize(string iban) =>
           iban.Replace(" ", "").ToUpper();
    }
}