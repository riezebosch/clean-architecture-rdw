using Microsoft.EntityFrameworkCore;

namespace BankCodeProviders.Database.IntegrationTests
{
    public class BankCodeContext : DbContext
    {
        public BankCodeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BankCode> BankCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankCode>().HasKey(b => b.Code);
            base.OnModelCreating(modelBuilder);
        }
    }
}