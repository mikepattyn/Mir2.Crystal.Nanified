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

}
