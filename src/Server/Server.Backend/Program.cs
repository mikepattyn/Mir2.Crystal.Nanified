// See https://aka.ms/new-console-template for more information
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Server.Database.Models;
using System.Text.Json;
using Server.Database.DbContexts;

Console.WriteLine("Hello, World!");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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