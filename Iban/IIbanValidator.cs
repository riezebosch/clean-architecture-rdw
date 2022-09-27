namespace Iban
{
    internal interface IIbanValidator
    {
        bool Validate(string iban);
    }
}