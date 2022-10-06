namespace IbanChecker.BankCodes.EF;

public class Adapter : IBankCodes
{
    private readonly BankCodeContext _context;

    public Adapter(BankCodeContext context) => this._context = context;

    public IEnumerable<string> Get() => _context.BankCodes.Select(x => x.Code);
}