using Persistance.Domain;

namespace Server.Database.Models;

public class DomainAccount : Entity<Guid>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public DateTime Birthdate { get; set; }
    public DateTime CreatedAt { get; set; }
    public int WrongPasswordCount { get; set; }
    public bool ResetPasswordRequired { get; set; }
    public string SecretQuestion { get; set; }
    public string SecretAnswer { get; set; }
    public byte[] Salt { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBanned { get; set; }
    public DateTime? LastActivity { get; set; }
    public bool HasExpandedStorage { get; set; }
    public string LastKnownIpAddress { get; set; }
    public string CreatedAtIpAddress { get; set; }
    public string BanReason { get; set; }
    public long Gold { get; set; }

    public ICollection<DomainAuction> Auctions { get; set; }
    public ICollection<DomainCharacter> Characters { get; set; }
    public ICollection<DomainItem> Storage { get; set; }

}