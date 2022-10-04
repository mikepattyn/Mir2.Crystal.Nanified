// See https://aka.ms/new-console-template for more information
using MediatR;
using Server.Database.DbContexts;

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
