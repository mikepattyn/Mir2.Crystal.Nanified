using Shared.Enums;

namespace Shared.Models.Items;

public class UserItem
{
    public ulong UniqueID;
    public int ItemIndex;

    public ItemInfo Info;
    public ushort CurrentDura, MaxDura;
    public ushort Count = 1,
        GemCount = 0;

    public RefinedValue RefinedValue = RefinedValue.None;
    public byte RefineAdded = 0;
    public int RefineSuccessChance = 0;

    public bool DuraChanged;
    public int SoulBoundId = -1;
    public bool Identified = false;
    public bool Cursed = false;

    public int WeddingRing = -1;

    public UserItem[] Slots = new UserItem[0];

    public DateTime BuybackExpiryDate;

    public ExpireInfo ExpireInfo;
    public RentalInformation RentalInformation;
    public SealedInfo SealedInfo;

    public bool IsShopItem;

    public Awake Awake = new Awake();

    public Stats AddedStats;

    public bool IsAdded
    {
        get { return AddedStats.Count > 0 || Slots.Length > Info.Slots; }
    }

    public int Weight
    {
        get { return Info.Type == ItemType.Amulet ? Info.Weight : Info.Weight * Count; }
    }

    public string FriendlyName
    {
        get { return Count > 1 ? string.Format("{0} ({1})", Info.FriendlyName, Count) : Info.FriendlyName; }
    }

    public UserItem(ItemInfo info)
    {
        SoulBoundId = -1;
        ItemIndex = info.Index;
        Info = info;
        AddedStats = new Stats();

        SetSlotSize();
    }
    public UserItem(BinaryReader reader, int version = int.MaxValue, int customVersion = int.MaxValue)
    {
        UniqueID = reader.ReadUInt64();
        ItemIndex = reader.ReadInt32();

        CurrentDura = reader.ReadUInt16();
        MaxDura = reader.ReadUInt16();

        if (version <= 84)
        {
            Count = (ushort)reader.ReadUInt32();
        }
        else
        {
            Count = reader.ReadUInt16();
        }

        if (version <= 84)
        {
            AddedStats = new Stats();

            AddedStats[Stat.MaxAC] = reader.ReadByte();
            AddedStats[Stat.MaxMAC] = reader.ReadByte();
            AddedStats[Stat.MaxDC] = reader.ReadByte();
            AddedStats[Stat.MaxMC] = reader.ReadByte();
            AddedStats[Stat.MaxSC] = reader.ReadByte();

            AddedStats[Stat.Accuracy] = reader.ReadByte();
            AddedStats[Stat.Agility] = reader.ReadByte();
            AddedStats[Stat.HP] = reader.ReadByte();
            AddedStats[Stat.MP] = reader.ReadByte();

            AddedStats[Stat.AttackSpeed] = reader.ReadSByte();
            AddedStats[Stat.Luck] = reader.ReadSByte();
        }

        SoulBoundId = reader.ReadInt32();
        byte Bools = reader.ReadByte();
        Identified = (Bools & 0x01) == 0x01;
        Cursed = (Bools & 0x02) == 0x02;

        if (version <= 84)
        {
            AddedStats[Stat.Strong] = reader.ReadByte();
            AddedStats[Stat.MagicResist] = reader.ReadByte();
            AddedStats[Stat.PoisonResist] = reader.ReadByte();
            AddedStats[Stat.HealthRecovery] = reader.ReadByte();
            AddedStats[Stat.SpellRecovery] = reader.ReadByte();
            AddedStats[Stat.PoisonRecovery] = reader.ReadByte();
            AddedStats[Stat.CriticalRate] = reader.ReadByte();
            AddedStats[Stat.CriticalDamage] = reader.ReadByte();
            AddedStats[Stat.Freezing] = reader.ReadByte();
            AddedStats[Stat.PoisonAttack] = reader.ReadByte();
        }

        int count = reader.ReadInt32();

        SetSlotSize(count);

        for (int i = 0; i < count; i++)
        {
            if (reader.ReadBoolean()) continue;
            UserItem item = new UserItem(reader, version, customVersion);
            Slots[i] = item;
        }

        if (version <= 84)
        {
            GemCount = (ushort)reader.ReadUInt32();
        }
        else
        {
            GemCount = reader.ReadUInt16();
        }

        if (version > 84)
        {
            AddedStats = new Stats(reader, version, customVersion);
        }

        Awake = new Awake(reader);

        RefinedValue = (RefinedValue)reader.ReadByte();
        RefineAdded = reader.ReadByte();

        if (version > 85)
        {
            RefineSuccessChance = reader.ReadInt32();
        }

        WeddingRing = reader.ReadInt32();

        if (version < 65) return;

        if (reader.ReadBoolean())
        {
            ExpireInfo = new ExpireInfo(reader, version, customVersion);
        }

        if (version < 76)
            return;

        if (reader.ReadBoolean())
            RentalInformation = new RentalInformation(reader, version, customVersion);

        if (version < 83) return;

        IsShopItem = reader.ReadBoolean();

        if (version < 92) return;

        if (reader.ReadBoolean())
        {
            SealedInfo = new SealedInfo(reader, version, customVersion);
        }
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(ItemIndex);

        writer.Write(CurrentDura);
        writer.Write(MaxDura);

        writer.Write(Count);
       
        writer.Write(SoulBoundId);
        byte Bools = 0;
        if (Identified) Bools |= 0x01;
        if (Cursed) Bools |= 0x02;
        writer.Write(Bools);

        writer.Write(Slots.Length);
        for (int i = 0; i < Slots.Length; i++)
        {
            writer.Write(Slots[i] == null);
            if (Slots[i] == null) continue;

            Slots[i].Save(writer);
        }

        writer.Write(GemCount);


        AddedStats.Save(writer);
        Awake.Save(writer);

        writer.Write((byte)RefinedValue);
        writer.Write(RefineAdded);
        writer.Write(RefineSuccessChance);

        writer.Write(WeddingRing);

        writer.Write(ExpireInfo != null);
        ExpireInfo?.Save(writer);

        writer.Write(RentalInformation != null);
        RentalInformation?.Save(writer);

        writer.Write(IsShopItem);

        writer.Write(SealedInfo != null);
        SealedInfo?.Save(writer);
    }

    public int GetTotal(Stat type)
    {
        return AddedStats[type] + Info.Stats[type];
    }

    public uint Price()
    {
        if (Info == null) return 0;

        uint p = Info.Price;


        if (Info.Durability > 0)
        {
            float r = ((Info.Price / 2F) / Info.Durability);

            p = (uint)(MaxDura * r);

            if (MaxDura > 0)
                r = CurrentDura / (float)MaxDura;
            else
                r = 0;

            p = (uint)Math.Floor(p / 2F + ((p / 2F) * r) + Info.Price / 2F);
        }


        p = (uint)(p * (AddedStats.Count * 0.1F + 1F));


        return p * Count;
    }
    public uint RepairPrice()
    {
        if (Info == null || Info.Durability == 0)
            return 0;

        var p = Info.Price;

        if (Info.Durability > 0)
        {
            p = (uint)Math.Floor(MaxDura * ((Info.Price / 2F) / Info.Durability) + Info.Price / 2F);
            p = (uint)(p * (AddedStats.Count * 0.1F + 1F));

        }

        var cost = p * Count - Price();

        if (RentalInformation == null)
            return cost;

        return cost * 2;
    }

    public uint Quality()
    {
        uint q = (uint)(AddedStats.Count + Awake.GetAwakeLevel() + 1);

        return q;
    }

    public uint AwakeningPrice()
    {
        if (Info == null) return 0;

        uint p = 1500;

        p = (uint)((p * (1 + Awake.GetAwakeLevel() * 2)) * (uint)Info.Grade);

        return p;
    }

    public uint DisassemblePrice()
    {
        if (Info == null) return 0;

        uint p = 1500 * (uint)Info.Grade;

        p = (uint)(p * ((AddedStats.Count + Awake.GetAwakeLevel()) * 0.1F + 1F));

        return p;
    }

    public uint DowngradePrice()
    {
        if (Info == null) return 0;

        uint p = 3000;

        p = (uint)((p * (1 + (Awake.GetAwakeLevel() + 1) * 2)) * (uint)Info.Grade);

        return p;
    }

    public uint ResetPrice()
    {
        if (Info == null) return 0;

        uint p = 3000 * (uint)Info.Grade;

        p = (uint)(p * (AddedStats.Count * 0.2F + 1F));

        return p;
    }
    public void SetSlotSize(int? size = null)
    {
        if (size == null)
        {
            switch (Info.Type)
            {
                case ItemType.Mount:
                    if (Info.Shape < 7)
                        size = 4;
                    else if (Info.Shape < 12)
                        size = 5;
                    break;
                case ItemType.Weapon:
                    if (Info.Shape == 49 || Info.Shape == 50)
                        size = 5;
                    break;
            }
        }

        if (size == null && Info == null) return;
        if (size != null && size == Slots.Length) return;
        if (size == null && Info != null && Info.Slots == Slots.Length) return;

        Array.Resize(ref Slots, size ?? Info.Slots);
    }

    public ushort Image
    {
        get
        {
            switch (Info.Type)
            {
                #region Amulet and Poison Stack Image changes
                case ItemType.Amulet:
                    if (Info.StackSize > 0)
                    {
                        switch (Info.Shape)
                        {
                            case 0: //Amulet
                                if (Count >= 300) return 3662;
                                if (Count >= 200) return 3661;
                                if (Count >= 100) return 3660;
                                return 3660;
                            case 1: //Grey Poison
                                if (Count >= 150) return 3675;
                                if (Count >= 100) return 2960;
                                if (Count >= 50) return 3674;
                                return 3673;
                            case 2: //Yellow Poison
                                if (Count >= 150) return 3672;
                                if (Count >= 100) return 2961;
                                if (Count >= 50) return 3671;
                                return 3670;
                        }
                    }
                    break;
            }

            #endregion

            return Info.Image;
        }
    }

    public UserItem Clone()
    {
        UserItem item = new UserItem(Info)
        {
            UniqueID = UniqueID,
            CurrentDura = CurrentDura,
            MaxDura = MaxDura,
            Count = Count,
            GemCount = GemCount,
            DuraChanged = DuraChanged,
            SoulBoundId = SoulBoundId,
            Identified = Identified,
            Cursed = Cursed,
            Slots = Slots,
            AddedStats = new Stats(AddedStats),
            Awake = Awake,

            RefineAdded = RefineAdded,

            ExpireInfo = ExpireInfo,
            RentalInformation = RentalInformation,
            SealedInfo = SealedInfo,

            IsShopItem = IsShopItem
        };

        return item;
    }

}