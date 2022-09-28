using Iban;

namespace BankCodeProviders.Database;

public class Provider : IBankCodeProvider
{
    private BankCodeContext context;

    public Provider(BankCodeContext context)
    {
        this.context = context;
    }

    public string[] BankCodes() =>
        context.BankCodes.Select(x => x.Code).ToArray();
}