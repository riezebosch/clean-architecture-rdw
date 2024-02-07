using LanguageExt;

namespace IbanChecker
{
    public interface IIbanValidator
    {
        Validation<string, string> IsValid(string? iban);
    }
}