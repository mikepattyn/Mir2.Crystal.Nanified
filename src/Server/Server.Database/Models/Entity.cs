namespace Server.Database.Models
{
    public class Entity { }
    public abstract class Entity<TId> : Entity
    {
        TId Id { get; set; }
    }
}