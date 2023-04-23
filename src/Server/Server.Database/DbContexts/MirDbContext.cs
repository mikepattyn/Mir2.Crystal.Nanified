using Microsoft.EntityFrameworkCore;
using Persistance.Domain;
using Server.Database.Models;

namespace Server.Database.DbContexts;
public class MirDbContext : DbContext
{
    public MirDbContext(DbContextOptions<MirDbContext> options) : base(options)
    {
    }

    public DbSet<DomainAccount> Accounts { get; set; }
    public DbSet<DomainAuction> Auctions { get; set; }
    public DbSet<DomainBuff> Buffs { get; set; }
    public DbSet<DomainConquestGuild> GuildConquests { get; set; }
    public DbSet<DomainDragon> Dragons { get; set; }
    public DbSet<DomainFriend> Friends { get; set; }
    public DbSet<DomainGuild> Guilds { get; set; }
    public DbSet<DomainHero> Heros { get; set; }
    public DbSet<DomainIntelligentCreature> IntelligentCreatures { get; set; }
    public DbSet<DomainItem> Items { get; set; }
    public DbSet<DomainMagic> Magics { get; set; }
    public DbSet<DomainMail> Mail { get; set; }
    public DbSet<DomainMap> Maps { get; set; }
    public DbSet<DomainMine> Mines { get; set; }
    public DbSet<DomainMonster> Monsters { get; set; }
    public DbSet<DomainMount> Mounts { get; set; }
    public DbSet<DomainMovement> Movements { get; set; }
    public DbSet<DomainNPC> Npcs { get; set; }
    public DbSet<DomainPet> Pets { get; set; }
    public DbSet<DomainPoison> Poisons { get; set; }
    public DbSet<DomainQuest> Quests { get; set; }
    public DbSet<DomainQuestProgress> QuestProgress { get; set; }
    public DbSet<DomainRecipe> Recipes { get; set; }
    public DbSet<DomainRespawn> Respawns { get; set; }
    public DbSet<DomainSafeZone> SafeZones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DomainCharacter>().HasKey(x => x.Id);
        modelBuilder.Entity<DomainItem>().HasKey(x => x.Id);
        modelBuilder.Entity<DomainSafeZone>().HasKey(x => x.Id);
        modelBuilder.Entity<DomainAccount>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainAuction>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainBuff>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainConquestGuild>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainDragon>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainFriend>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainGuild>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainHero>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainIntelligentCreature>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainItem>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMagic>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMail>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMap>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMine>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMonster>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMount>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainMovement>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainNPC>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainPet>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainPoison>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainQuest>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainQuestProgress>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainRecipe>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainRespawn>().HasKey(x=>x.Id);
        modelBuilder.Entity<DomainSafeZone>().HasKey(x => x.Id);

        modelBuilder.Entity<DomainCharacter>().Ignore(x => x.BindLocation);
        modelBuilder.Entity<DomainCharacter>().Ignore(x => x.CurrentLocation);
        modelBuilder.Entity<DomainCharacter>().Ignore(x => x.Flags);

    }
}
