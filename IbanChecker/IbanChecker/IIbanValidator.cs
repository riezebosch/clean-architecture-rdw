namespace IbanChecker
{
    public interface IIbanValidator
    {
        bool IsValid(string? iban);
    }
}