using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankCodeProviders.Database.Migrations
{
    internal class BankCodeContextFactory : IDesignTimeDbContextFactory<BankCodeContext>
    {
        public BankCodeContext CreateDbContext(string[] args) =>

            new BankCodeContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=bankcodes;Integrated Security=SSPI;", o => o.MigrationsAssembly(GetType().Assembly.GetName().Name)).Options);
    }
}
