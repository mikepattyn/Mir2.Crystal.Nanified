using Shared.Enums;
using Shared.Models.Client;
using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class HeroInformation : UserInformation
{
    public bool AutoPot;
    public byte AutoHPPercent;
    public byte AutoMPPercent;
    public int HPItemIndex;
    public int MPItemIndex;
    public override short Index
    {
        get { return (short)ServerPacketIds.HeroInformation; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
        Level = reader.ReadUInt16();
        Hair = reader.ReadByte();

        HP = reader.ReadInt32();
        MP = reader.ReadInt32();

        Experience = reader.ReadInt64();
        MaxExperience = reader.ReadInt64();

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

        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
        {
            Magics.Add(new ClientMagic(reader));
        }

        AutoPot = reader.ReadBoolean();
        AutoHPPercent = reader.ReadByte();
        AutoMPPercent = reader.ReadByte();
        HPItemIndex = reader.ReadInt32();
        MPItemIndex = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
        writer.Write((byte)Class);
        writer.Write((byte)Gender);
        writer.Write(Level);
        writer.Write(Hair);

        writer.Write(HP);
        writer.Write(MP);

        writer.Write(Experience);
        writer.Write(MaxExperience);

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

        writer.Write(Magics.Count);
        for (int i = 0; i < Magics.Count; i++)
        {
            Magics[i].Save(writer);
        }

        writer.Write(AutoPot);
        writer.Write(AutoHPPercent);
        writer.Write(AutoMPPercent);
        writer.Write(HPItemIndex);
        writer.Write(MPItemIndex);
    }
}