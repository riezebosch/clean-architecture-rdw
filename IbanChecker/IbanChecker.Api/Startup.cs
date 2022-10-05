using Microsoft.AspNetCore.Mvc;

namespace IbanChecker.Api;

public static class Startup
{
    public static WebApplication App(string[] args, Action<IServiceCollection>? configure = null)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder
            .Services
            .AddScoped<IIbanValidator, IbanValidator>()
            .AddScoped<IBankCodes, BankCodes.InMemory.Adapter>();

        configure?.Invoke(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        app.MapGet("/{iban}", (string iban, [FromServices]IIbanValidator validator) => validator.IsValid(iban));

        return app;
    }
}