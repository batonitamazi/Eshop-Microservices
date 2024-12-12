using Ordering.API;
using Ordering.Application;
using Ordering.Instrastructure;
using Ordering.Instrastructure.Data.extensions;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the Container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();


//Configure the HTTP Request Pipeline
app.UseApiServices();

if(app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}    

app.Run();
