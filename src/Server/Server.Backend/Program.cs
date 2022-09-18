// See https://aka.ms/new-console-template for more information
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Server.Database.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Server.Database.DbContexts;

Console.WriteLine("Hello, World!");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<MirDbContext>(); // <- this line of code starts up the database connection.

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

public record GetDatabaseEntitiesQuery : IRequest<IEnumerable<DatabaseEntity>>;
public record GetDatabaseEntitiesQueryHandler : IRequestHandler<GetDatabaseEntitiesQuery, IEnumerable<DatabaseEntity>>
{
    public Task<IEnumerable<DatabaseEntity>> Handle(GetDatabaseEntitiesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(typeof(DomainAccount).Assembly
            .ExportedTypes.Where(x => x.Name.StartsWith("Domain"))
            .Select(x => new DatabaseEntity(x)));
    }
}


public class CreateDatabaseRecordCommand : IRequest
{
    public Entity Entity { get; set; }
}

public abstract class DatabaseHandler
{
    internal readonly MirDbContext Context;

    protected DatabaseHandler(MirDbContext context)
    {
        Context = context;
    }
}

public class CreateDatabaseRecordCommandHandler : DatabaseHandler, IRequestHandler<CreateDatabaseRecordCommand>
{
    public CreateDatabaseRecordCommandHandler(MirDbContext context) : base(context)
    {
    }

    public async Task<Unit> Handle(CreateDatabaseRecordCommand request, CancellationToken cancellationToken)
    {
        await Context.AddAsync(request, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

public class DashboardData
{
    public int OnlinePlayers { get; set; }
    public TimeSpan ServerTimeOnline { get; set; }
    public int ActiveDungeons { get; set; }
    public int TotalMonstersSpawned { get; set; }
    public int HighestPlayerLevel { get; set; }
}
public record GetDashboardDataQuery : IRequest<DashboardData>;
public class GetDashboardDataQueryHandler : DatabaseHandler, IRequestHandler<GetDashboardDataQuery, DashboardData>
{
    public GetDashboardDataQueryHandler(MirDbContext context) : base(context)
    {
    }

    public async Task<DashboardData> Handle(GetDashboardDataQuery request, CancellationToken cancellationToken)
    {
        var data = new DashboardData();
        var players = await Context.Accounts.CountAsync(x => x.LastActivity > DateTime.UtcNow.AddMinutes(10), cancellationToken);
        data.OnlinePlayers = players;
        data.ServerTimeOnline = TimeSpan.FromMinutes(10);
        data.ActiveDungeons = 22;
        data.TotalMonstersSpawned = 42312;
        data.HighestPlayerLevel = 56;
        return data;
    }
}
