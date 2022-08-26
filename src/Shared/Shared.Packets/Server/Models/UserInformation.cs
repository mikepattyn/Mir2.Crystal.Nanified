using Shared.Enums;
using Shared.Models.Client;
using Shared.Models.IntelligentCreature;
using Shared.Models.Items;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public class UserInformation : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UserInformation; }
    }

    public uint ObjectID;
    public uint RealId;
    public string Name = string.Empty;
    public string GuildName = string.Empty;
    public string GuildRank = string.Empty;
    public Color NameColour;
    public MirClass Class;
    public MirGender Gender;
    public ushort Level;
    public Point Location;
    public MirDirection Direction;
    public byte Hair;
    public int HP, MP;
    public long Experience, MaxExperience;

    public LevelEffects LevelEffects;

    public bool HasHero;
    public HeroBehaviour HeroBehaviour;
    public UserItem[] Inventory, Equipment, QuestInventory;
    public uint Gold, Credit;

    public bool HasExpandedStorage;
    public DateTime ExpandedStorageExpiryTime;

    public List<ClientMagic> Magics = new List<ClientMagic>();

    public List<ClientIntelligentCreature> IntelligentCreatures = new List<ClientIntelligentCreature>();
    public IntelligentCreatureType SummonedCreatureType = IntelligentCreatureType.None;
    public bool CreatureSummoned;
    public bool AllowObserve;
    public bool Observer;



    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        RealId = reader.ReadUInt32();
        Name = reader.ReadString();
        GuildName = reader.ReadString();
        GuildRank = reader.ReadString();
        NameColour = Color.FromArgb(reader.ReadInt32());
        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
        Level = reader.ReadUInt16();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
        Hair = reader.ReadByte();
        HP = reader.ReadInt32();
        MP = reader.ReadInt32();

        Experience = reader.ReadInt64();
        MaxExperience = reader.ReadInt64();

        LevelEffects = (LevelEffects)reader.ReadByte();
        HasHero = reader.ReadBoolean();
        HeroBehaviour = (HeroBehaviour)reader.ReadByte();

        if (reader.ReadBoolean())
        {
            Inventory = new UserItem[reader.ReadInt32()];
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (!reader.ReadBoolean()) continue;
                Inventory[i] = new UserItem(reader);
            }
        }

        if (reader.ReadBoolean())
        {
            Equipment = new UserItem[reader.ReadInt32()];
            for (int i = 0; i < Equipment.Length; i++)
            {
                if (!reader.ReadBoolean()) continue;
                Equipment[i] = new UserItem(reader);
            }
        }

        if (reader.ReadBoolean())
        {
            QuestInventory = new UserItem[reader.ReadInt32()];
            for (int i = 0; i < QuestInventory.Length; i++)
            {
                if (!reader.ReadBoolean()) continue;
                QuestInventory[i] = new UserItem(reader);
            }
        }

        Gold = reader.ReadUInt32();
        Credit = reader.ReadUInt32();

        HasExpandedStorage = reader.ReadBoolean();
        ExpandedStorageExpiryTime = DateTime.FromBinary(reader.ReadInt64());

        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
        {
            Magics.Add(new ClientMagic(reader));
        }

        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            IntelligentCreatures.Add(new ClientIntelligentCreature(reader));
        }
        SummonedCreatureType = (IntelligentCreatureType)reader.ReadByte();
        CreatureSummoned = reader.ReadBoolean();
        AllowObserve = reader.ReadBoolean();
        Observer = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(RealId);
        writer.Write(Name);
        writer.Write(GuildName);
        writer.Write(GuildRank);
        writer.Write(NameColour.ToArgb());
        writer.Write((byte)Class);
        writer.Write((byte)Gender);
        writer.Write(Level);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
        writer.Write(Hair);
        writer.Write(HP);
        writer.Write(MP);

        writer.Write(Experience);
        writer.Write(MaxExperience);

        writer.Write((byte)LevelEffects);
        writer.Write(HasHero);
        writer.Write((byte)HeroBehaviour);

        writer.Write(Inventory != null);
        if (Inventory != null)
        {
            writer.Write(Inventory.Length);
            for (int i = 0; i < Inventory.Length; i++)
            {
                writer.Write(Inventory[i] != null);
                if (Inventory[i] == null) continue;

                Inventory[i].Save(writer);
            }

        }

        writer.Write(Equipment != null);
        if (Equipment != null)
        {
            writer.Write(Equipment.Length);
            for (int i = 0; i < Equipment.Length; i++)
            {
                writer.Write(Equipment[i] != null);
                if (Equipment[i] == null) continue;

                Equipment[i].Save(writer);
            }
        }

        writer.Write(QuestInventory != null);
        if (QuestInventory != null)
        {
            writer.Write(QuestInventory.Length);
            for (int i = 0; i < QuestInventory.Length; i++)
            {
                writer.Write(QuestInventory[i] != null);
                if (QuestInventory[i] == null) continue;

                QuestInventory[i].Save(writer);
            }
        }

        writer.Write(Gold);
        writer.Write(Credit);

        writer.Write(HasExpandedStorage);
        writer.Write(ExpandedStorageExpiryTime.ToBinary());

        writer.Write(Magics.Count);
        for (int i = 0; i < Magics.Count; i++)
        {
            Magics[i].Save(writer);
        }

        writer.Write(IntelligentCreatures.Count);
        for (int i = 0; i < IntelligentCreatures.Count; i++)
        {
            IntelligentCreatures[i].Save(writer);
        }

        writer.Write((byte)SummonedCreatureType);
        writer.Write(CreatureSummoned);
        writer.Write(AllowObserve);
        writer.Write(Observer);
    }
}