using BankCodeProviders.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

await using var context = new BankCodeContext(new DbContextOptionsBuilder()
        .UseSqlServer(args[0], o => o.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
        .LogTo(o => Console.WriteLine(o))
    .Options);
await context.Database.MigrateAsync();