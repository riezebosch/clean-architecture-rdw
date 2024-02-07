using LanguageExt;
using static LanguageExt.Prelude;

namespace IbanChecker;

public class IbanValidator : IIbanValidator
{
    private readonly IBankCodes _provider;

    public IbanValidator(IBankCodes provider)
    {
        _provider = provider;
    }

    public Validation<string, string> IsValid(string? iban) =>
        NotEmpty(iban)
            .Bind(CheckCountryCode)
            .Bind(CheckChecksum)
            .Bind(CheckBankCode);

    private static Validation<string, string> NotEmpty(string? iban) =>
        !string.IsNullOrEmpty(iban)
            ? Success<string, string>(iban)
            : Fail<string, string>("Input is empty");

    private static Validation<string, string> CheckCountryCode(string iban) => 
        iban.StartsWith("NL") 
            ? Success<string, string>(iban)
            : Fail<string, string>("Dutch iban should start with NL");

    private static Validation<string, string> CheckChecksum(string iban) =>
        char.IsNumber(iban[2]) && char.IsNumber(iban[3])
            ? Success<string, string>(iban)
            : Fail<string, string>("Checksum should consist out of 2 digits");

    private Validation<string, string> CheckBankCode(string iban) =>
        _provider
            .Get()
            .Contains(iban.Substring(4, 4))
            ? Success<string, string>(iban)
            : Fail<string, string>("Invalid bank code");
}