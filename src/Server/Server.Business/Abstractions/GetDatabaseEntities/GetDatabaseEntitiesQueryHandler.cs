// See https://aka.ms/new-console-template for more information
using Server.Database.Models;
using MediatR;

public record GetDatabaseEntitiesQueryHandler : IRequestHandler<GetDatabaseEntitiesQuery, IEnumerable<DatabaseEntity>>
{
    public Task<IEnumerable<DatabaseEntity>> Handle(GetDatabaseEntitiesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(typeof(DomainAccount).Assembly
            .ExportedTypes.Where(x => x.Name.StartsWith("Domain"))
            .Select(x => new DatabaseEntity(x)));
    }
}
