using Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencyInjection();
// Builder
var app = builder.Build();

app.AddMiddleware();
app.Run();
