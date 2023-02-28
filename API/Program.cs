using CuentasPorCobrar.Shared;
using Microsoft.AspNetCore.Mvc.Formatters;
using static System.Console;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCuentasContext();

builder.Services.AddControllers(options =>
{
    WriteLine("Default ouput formatters:");
    foreach (IOutputFormatter formatter in options.OutputFormatters)
    {
        OutputFormatter? mediaFormatter =  formatter as OutputFormatter;
        if (mediaFormatter is null)
        {
            WriteLine($" {formatter.GetType().Name}");
        }
        else //OutputFormatter class has SupportedMediaTypes
        {
            WriteLine(" {0}, Media types: {1}",
                mediaFormatter.GetType().Name,
                string.Join(", ",
                mediaFormatter.SupportedMediaTypes));

        }
    }
})
    .AddXmlDataContractSerializerFormatters()
    .AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(doc =>
{
    doc.SwaggerDoc("v1", new()
    {
        Title="Cuentas Por Cobrar Service API",
        Version="v1"
    });


});
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>(); 
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(doc =>
    {
        doc.SwaggerEndpoint("/swagger/v1/swagger.json", "Cuentas por Cobrar Service API Version 1");

        doc.SupportedSubmitMethods(new[]
        {
            SubmitMethod.Get, SubmitMethod.Post,
            SubmitMethod.Put, SubmitMethod.Delete
        });
    });
}


app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;


try
{
    var context = services.GetRequiredService<CuentasporcobrardbContext>();
    context.Database.Migrate(); 

}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error ocurred during migration"); 

}


app.Run();
