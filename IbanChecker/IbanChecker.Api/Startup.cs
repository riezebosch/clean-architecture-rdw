namespace IbanChecker.Api;

public static class Startup
{
    public static WebApplication App(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        app.MapGet("/{iban}", (string iban) => new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban));

        return app;
    }
}