// See https://aka.ms/new-console-template for more information
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Server.Database.Models;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Server.Database.DbContexts;

Console.WriteLine("Hello, World!");
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<MirDbContext>(builder.Configuration.GetConnectionString("Mir2Db"));
builder.Services.AddMediatR(typeof(GetDashboardDataQuery).Assembly); // <- this does not add mediatr itself. 
builder.Services.AddMemoryCache();

                           /*Interface,Implementation*/
builder.Services.AddScoped<IMediator, Mediator>(); // <- my mistake, the interface type is IMediator the implementation is Mediator

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
                .AddOpenApiDocument();
builder.Services.AddCors(options =>
{
    options.AddPolicy("_AllowSpecificOrigins", 
        policy => { policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
        });
});

var app = builder.Build();

app.UseOpenApi()
   .UseSwaggerUI();

app.MapGet("/", () => 
    JsonSerializer.Serialize(typeof(DomainAccount).Assembly
        .ExportedTypes.Where(x => x.Name.StartsWith("Domain"))
        .Select(x => new DatabaseEntity(x))
    .ToList()));

app.MapGet("/dashboard", async (IMediator Mediator) => 
    await Mediator.Send(new GetDashboardDataQuery()));

app.UseHttpsRedirection()
   .UseAuthorization()
   .UseRouting()
   .UseCors("_AllowSpecificOrigins");

app.MapControllers();

app.Run();