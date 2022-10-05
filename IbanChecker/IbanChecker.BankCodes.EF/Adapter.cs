namespace IbanChecker.BankCodes.EF;

public class Adapter : IBankCodes
{
    private readonly BankCodeContext context;

    public Adapter(BankCodeContext context) => this.context = context;

    public IEnumerable<string> Get() => context.BankCodes.Select(x => x.Code);
}