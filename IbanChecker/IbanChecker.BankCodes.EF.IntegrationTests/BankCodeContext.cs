using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests
{
    internal class BankCodeContext : DbContext
    {
        public BankCodeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BankCode>().HasKey(x => x.Code);
        }

        public DbSet<BankCode> BankCodes { get; internal set; }


    }
}