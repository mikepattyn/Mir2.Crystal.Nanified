// See https://aka.ms/new-console-template for more information
using Server.Database.DbContexts;

public abstract class DatabaseHandler
{
    internal readonly MirDbContext Context;

    protected DatabaseHandler(MirDbContext context)
    {
        Context = context;
    }
}
