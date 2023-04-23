// See https://aka.ms/new-console-template for more information
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Server.Database.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<MirDbContext>(builder.Configuration.GetConnectionString("Mir2Db"));
builder.Services.AddMediatR(typeof(GetDashboardDataQuery).Assembly);
builder.Services.AddMemoryCache();

                          
builder.Services.AddScoped<IMediator, Mediator>();

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

app.UseCrystalM2Nanified();


app.UseHttpsRedirection()
   .UseAuthorization()
   .UseRouting()
   .UseCors("_AllowSpecificOrigins");

app.MapControllers();

app.Run();