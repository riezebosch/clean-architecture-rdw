using Iban;

namespace BankCodeProviders.InMemory
{
    public class Provider : IBankCodeProvider
    {
        public string[] BankCodes() =>
            new[] { "ABNA", "INGB" };
    }
}