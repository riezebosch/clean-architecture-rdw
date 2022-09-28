using BankCodeProviders.Database;
using Iban.Tests;

namespace Iban.API
{
    public static class WebApplicationBuilderStartup
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder
                .Services
                .AddScoped<IbanValidator>()
                .AddScoped<IBankCodeProvider, Provider>()
                .AddSqlServer<BankCodeContext>("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=rdw-p");

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void RegisterMiddleWare(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
