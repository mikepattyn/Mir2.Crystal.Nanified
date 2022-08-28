// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Server.Database.Models;
using System.Collections;
using System.Text.Json;

Console.WriteLine("Hello, World!");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
                .AddOpenApiDocument();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddCors(options =>
{
    options.AddPolicy("_AllowSpecificOrigins", 
        policy => { policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
        });
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUI();

app.MapGet("/", () => 
    JsonSerializer.Serialize(typeof(DomainAccount).Assembly
        .ExportedTypes.Where(x => x.Name.StartsWith("Domain"))
        .Select(x => new EntityViewModel(x))
    .ToList()));

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting().UseCors("_AllowSpecificOrigins");
app.MapControllers();

app.Run();

class EntityViewModel
{
    Type entityType;
    public EntityViewModel(Type type)
    {
        entityType = type;
    }
    public string Name => entityType.Name.Replace("Domain", "");
    public string[] Headers
    {
        get
        {
            var retVal = entityType
                .GetProperties()
                .Select(x =>
                {
                    if (x.PropertyType.Name.Contains(nameof(ICollection)))
                        return $"{x.Name} ({x.PropertyType.GenericTypeArguments.First().Name.Replace("Domain", "")})";
                    return $"{x.Name} ({x.PropertyType.Name})";
                })
                .ToArray();

            if (entityType.BaseType!.GetFields().Any(x=>x.Name.Contains("Id")))
            {
                retVal = retVal.Prepend($"Id ({entityType.BaseType!.GetProperties().First()!.Name})").ToArray();
            }

            return retVal;
        }
    }
    public IEnumerable<string> Values { get; set; }
}