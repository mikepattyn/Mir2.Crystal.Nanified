using Shared.Enums;
using System.Text.RegularExpressions;

namespace Shared.Models.Items;

public class ItemInfo
{
    public int Index;
    public string Name = string.Empty;
    public ItemType Type;
    public ItemGrade Grade;
    public RequiredType RequiredType = RequiredType.Level;
    public RequiredClass RequiredClass = RequiredClass.None;
    public RequiredGender RequiredGender = RequiredGender.None;
    public ItemSet Set;

    public short Shape;
    public byte Weight, Light, RequiredAmount;

    public ushort Image, Durability;

    public uint Price; 
    public ushort StackSize = 1;

    public bool StartItem;
    public byte Effect;

    public bool NeedIdentify, ShowGroupPickup, GlobalDropNotify;
    public bool ClassBased;
    public bool LevelBased;
    public bool CanMine;
    public bool CanFastRun;
    public bool CanAwakening;

    public BindMode Bind = BindMode.None;

    public SpecialItemMode Unique = SpecialItemMode.None;
    public byte RandomStatsId;
    public RandomItemStat RandomStats;
    public string ToolTip = string.Empty;

    public byte Slots;

    public Stats Stats;

    public bool IsConsumable
    {
        get { return Type == ItemType.Potion || Type == ItemType.Scroll || Type == ItemType.Food || Type == ItemType.Transform || Type == ItemType.Script || Type == ItemType.SealedHero; }
    }
    public bool IsFishingRod
    {
        get { return Globals.FishingRodShapes.Contains(Shape); }
    }

    public string FriendlyName
    {
        get
        {
            string temp = Name;
            temp = Regex.Replace(temp, @"\d+$", string.Empty); //hides end numbers
            temp = Regex.Replace(temp, @"\[[^]]*\]", string.Empty); //hides square brackets

            return temp;
        }
    }

    public ItemInfo() 
    {
        Stats = new Stats();
    }

    public ItemInfo(BinaryReader reader, int version = int.MaxValue, int customVersion = int.MaxValue)
    {
        Index = reader.ReadInt32();
        Name = reader.ReadString();
        Type = (ItemType)reader.ReadByte();
        Grade = (ItemGrade)reader.ReadByte();
        RequiredType = (RequiredType)reader.ReadByte();
        RequiredClass = (RequiredClass)reader.ReadByte();
        RequiredGender = (RequiredGender)reader.ReadByte();
        Set = (ItemSet)reader.ReadByte();

        Shape = reader.ReadInt16();
        Weight = reader.ReadByte();
        Light = reader.ReadByte();
        RequiredAmount = reader.ReadByte();

        Image = reader.ReadUInt16();
        Durability = reader.ReadUInt16();

        if (version <= 84)
        {
            StackSize = (ushort)reader.ReadUInt32();
        }
        else
        {
            StackSize = reader.ReadUInt16();
        }

        Price = reader.ReadUInt32();

        if (version <= 84)
        {
            Stats = new Stats();
            Stats[Stat.MinAC] = reader.ReadByte();
            Stats[Stat.MaxAC] = reader.ReadByte();
            Stats[Stat.MinMAC] = reader.ReadByte();
            Stats[Stat.MaxMAC] = reader.ReadByte();
            Stats[Stat.MinDC] = reader.ReadByte();
            Stats[Stat.MaxDC] = reader.ReadByte();
            Stats[Stat.MinMC] = reader.ReadByte();
            Stats[Stat.MaxMC] = reader.ReadByte();
            Stats[Stat.MinSC] = reader.ReadByte();
            Stats[Stat.MaxSC] = reader.ReadByte();
            Stats[Stat.HP] = reader.ReadUInt16();
            Stats[Stat.MP] = reader.ReadUInt16();
            Stats[Stat.Accuracy] = reader.ReadByte();
            Stats[Stat.Agility] = reader.ReadByte();

            Stats[Stat.Luck] = reader.ReadSByte();
            Stats[Stat.AttackSpeed] = reader.ReadSByte();
        }

        StartItem = reader.ReadBoolean();

        if (version <= 84)
        {
            Stats[Stat.BagWeight] = reader.ReadByte();
            Stats[Stat.HandWeight] = reader.ReadByte();
            Stats[Stat.WearWeight] = reader.ReadByte();
        }

        Effect = reader.ReadByte();

        if (version <= 84)
        {
            Stats[Stat.Strong] = reader.ReadByte();
            Stats[Stat.MagicResist] = reader.ReadByte();
            Stats[Stat.PoisonResist] = reader.ReadByte();
            Stats[Stat.HealthRecovery] = reader.ReadByte();
            Stats[Stat.SpellRecovery] = reader.ReadByte();
            Stats[Stat.PoisonRecovery] = reader.ReadByte();
            Stats[Stat.HPRatePercent] = reader.ReadByte();
            Stats[Stat.MPRatePercent] = reader.ReadByte();
            Stats[Stat.CriticalRate] = reader.ReadByte();
            Stats[Stat.CriticalDamage] = reader.ReadByte();
        }


        byte bools = reader.ReadByte();
        NeedIdentify = (bools & 0x01) == 0x01;
        ShowGroupPickup = (bools & 0x02) == 0x02;
        ClassBased = (bools & 0x04) == 0x04;
        LevelBased = (bools & 0x08) == 0x08;
        CanMine = (bools & 0x10) == 0x10;

        if (version >= 77)
        {
            GlobalDropNotify = (bools & 0x20) == 0x20;
        }

        if (version <= 84)
        {
            Stats[Stat.MaxACRatePercent] = reader.ReadByte();
            Stats[Stat.MaxMACRatePercent] = reader.ReadByte();
            Stats[Stat.Holy] = reader.ReadByte();
            Stats[Stat.Freezing] = reader.ReadByte();
            Stats[Stat.PoisonAttack] = reader.ReadByte();
        }

        Bind = (BindMode)reader.ReadInt16();

        if (version <= 84)
        {
            Stats[Stat.Reflect] = reader.ReadByte();
            Stats[Stat.HPDrainRatePercent] = reader.ReadByte();
        }

        Unique = (SpecialItemMode)reader.ReadInt16();
        RandomStatsId = reader.ReadByte();

        CanFastRun = reader.ReadBoolean();

        CanAwakening = reader.ReadBoolean();

        if (version > 83)
        {
            Slots = reader.ReadByte();
        }

        if (version > 84)
        {
            Stats = new Stats(reader, version, customVersion);
        }

        bool isTooltip = reader.ReadBoolean();
        if (isTooltip)
        {
            ToolTip = reader.ReadString();
        }

        if (version < 70) //before db version 70 all specialitems had wedding rings disabled, after that it became a server option
        {
            if ((Type == ItemType.Ring) && (Unique != SpecialItemMode.None))
                Bind |= BindMode.NoWeddingRing;
        }
    }



    public void Save(BinaryWriter writer)
    {
        writer.Write(Index);
        writer.Write(Name);
        writer.Write((byte)Type);
        writer.Write((byte)Grade);
        writer.Write((byte)RequiredType);
        writer.Write((byte)RequiredClass);
        writer.Write((byte)RequiredGender);
        writer.Write((byte)Set);

        writer.Write(Shape);
        writer.Write(Weight);
        writer.Write(Light);
        writer.Write(RequiredAmount);

        writer.Write(Image);
        writer.Write(Durability);

        writer.Write(StackSize);
        writer.Write(Price);

        writer.Write(StartItem);

        writer.Write(Effect);

        byte bools = 0;
        if (NeedIdentify) bools |= 0x01;
        if (ShowGroupPickup) bools |= 0x02;
        if (ClassBased) bools |= 0x04;
        if (LevelBased) bools |= 0x08;
        if (CanMine) bools |= 0x10;
        if (GlobalDropNotify) bools |= 0x20;
        writer.Write(bools);
        
        writer.Write((short)Bind);        
        writer.Write((short)Unique);

        writer.Write(RandomStatsId);

        writer.Write(CanFastRun);
        writer.Write(CanAwakening);
        writer.Write(Slots);

        Stats.Save(writer);

        writer.Write(ToolTip != null);
        if (ToolTip != null)
            writer.Write(ToolTip);

    }

    public static ItemInfo FromText(string text)
    {
        return null;
    }

    public string ToText()
    {
        return null;
    }

    public override string ToString()
    {
        return string.Format("{0}: {1}", Index, Name);
    }

}