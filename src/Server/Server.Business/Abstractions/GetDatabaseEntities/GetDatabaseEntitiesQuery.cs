// See https://aka.ms/new-console-template for more information
using MediatR;

public record GetDatabaseEntitiesQuery : IRequest<IEnumerable<DatabaseEntity>>;
