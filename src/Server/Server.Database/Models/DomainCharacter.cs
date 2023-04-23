using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Server.Database.Models;
using Shared.Enums;
using Shared.Models.Items;

namespace Persistance.Domain;

public class DomainCharacter : Entity<long>
{
    public string Name { get; set; }
    public ushort Level { get; set; }
    public MirClass Class { get; set; }
    public MirGender Gender { get; set; }
    public byte Hair { get; set; }
    public string CreationIP { get; set; }
    public DateTime CreationDate { get; set; }

    public bool Banned { get; set; }
    public string BanReason { get; set; }
    public DateTime ExpiryDate { get; set; }

    public bool ChatBanned { get; set; }
    public DateTime ChatBanExpiryDate { get; set; }

    public string LastIP { get; set; }
    public DateTime LastLogoutDate { get; set; }
    public DateTime LastLoginDate { get; set; }

    public bool Deleted;
    public DateTime DeleteDate { get; set; }

    //Marriage
    public int Married { get; set; } = 0;
    public DateTime MarriedDate { get; set; }

    //Mentor
    public int Mentor { get; set; } = 0;
    public DateTime MentorDate { get; set; }
    public bool IsMentor { get; set; }
    public long MentorExp { get; set; } = 0;

    //Location
    public int CurrentMapIndex { get; set; }
    [NotMapped]
    public Point CurrentLocation { get; set; }
    public MirDirection Direction { get; set; }
    public int BindMapIndex { get; set; }

    [NotMapped]
    public Point BindLocation { get; set; }

    public int HP { get; set; }
    public int MP { get; set; }
    public long Experience { get; set; }

    public AttackMode AMode { get; set; }
    public PetMode PMode { get; set; }
    public bool AllowGroup { get; set; }
    public bool AllowTrade { get; set; }
    public bool AllowObserve { get; set; }

    public int PKPoints { get; set; }

    public bool NewDay { get; set; }

    public bool Thrusting { get; set; }
    public bool HalfMoon { get; set; }
    public bool CrossHalfMoon { get; set; }
    public bool DoubleSlash { get; set; }
    public byte MentalState { get; set; }
    public byte MentalStateLvl { get; set; }
    public bool HasRentedItem { get; set; }
    public long CollectTime { get; set; }
    public int PearlCount { get; set; }

    public ICollection<DomainItem> Inventory { get; set; }
    public ICollection<DomainItem> Equipment { get; set; }
    public ICollection<DomainItem> Trade { get; set; }
    public ICollection<DomainItem> QuestInventory { get; set; }
    public ICollection<DomainItem> Refine { get; set; }
    public ICollection<ItemRentalInformation> RentedItems { get; set; }
    public ICollection<ItemRentalInformation> RentedItemsToRemove { get; set; }
    public ICollection<DomainMagic> Magics { get; set; }
    public ICollection<DomainBuff> Buffs { get; set; }
    public ICollection<DomainPoison> Poisons { get; set; }
    public ICollection<DomainMail> Mail { get; set; }
    public ICollection<DomainFriend> Friends { get; set; }
    public ICollection<DomainIntelligentCreature> IntelligentCreatures { get; set; }
    public ICollection<DomainQuestProgress> CurrentQuests { get; set; }
    public ICollection<DomainQuestProgress> CompletedQuests { get; set; }
    [NotMapped]
    public bool[] Flags { get; set; }


    public DomainItem CurrentRefine { get; set; }
    public DomainGuild Guild { get; set; }
    public DomainAccount Account { get; set; }
    public DomainMount Mount { get; set; }

    public DomainPlayer Player { get; set; }
}