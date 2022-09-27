using Iban.API;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();
app.RegisterMiddleWare();

app.Run();

