using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF;

public class BankCodeContext : DbContext
{
    public BankCodeContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<BankCode>()
            .HasKey(x => x.Code);
        modelBuilder
            .Entity<BankCode>()
            .Property(x => x.Code)
            .HasMaxLength(4);
    }

    public DbSet<BankCode> BankCodes { get; internal set; }


}