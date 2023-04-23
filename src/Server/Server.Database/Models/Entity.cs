namespace Server.Database.Models
{
    public class Entity { }
    public abstract class Entity<TId> : Entity
    {
        public TId Id { get; set; }
    }
}