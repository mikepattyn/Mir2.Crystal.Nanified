using Shared;

namespace Persistance.DbModels
{
    public abstract class Entity<TId>
    {
        TId Id { get; set; }
    }
}