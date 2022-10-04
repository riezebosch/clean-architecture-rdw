namespace IbanChecker.BankCodes.InMemory
{
    public class Adapter : IBankCodes
    {
        public IEnumerable<string> Get()
        {
            return new[] { "ABNA", "INGB" };
        }
    }
}