namespace Iban
{
    public class BankCodeProvider : IBankCodeProvider
    {
        public string[] BankCodes() =>
            new[] { "ABNA", "INGB" };
    }
}