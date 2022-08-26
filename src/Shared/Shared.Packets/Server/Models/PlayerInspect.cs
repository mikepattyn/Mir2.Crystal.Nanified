using Shared.Enums;
using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class PlayerInspect : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.PlayerInspect; }
    }

    public override bool Observable
    {
        get { return false; }
    }

    public string Name = string.Empty;
    public string GuildName = string.Empty;
    public string GuildRank = string.Empty;
    public UserItem[] Equipment;
    public MirClass Class;
    public MirGender Gender;
    public byte Hair;
    public ushort Level;
    public string LoverName;
    public bool AllowObserve;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        GuildName = reader.ReadString();
        GuildRank = reader.ReadString();
        Equipment = new UserItem[reader.ReadInt32()];
        for (int i = 0; i < Equipment.Length; i++)
        {
            if (reader.ReadBoolean())
                Equipment[i] = new UserItem(reader);
        }

        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
        Hair = reader.ReadByte();
        Level = reader.ReadUInt16();
        LoverName = reader.ReadString();
        AllowObserve = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(GuildName);
        writer.Write(GuildRank);
        writer.Write(Equipment.Length);
        for (int i = 0; i < Equipment.Length; i++)
        {
            UserItem T = Equipment[i];
            writer.Write(T != null);
            if (T != null) T.Save(writer);
        }

        writer.Write((byte)Class);
        writer.Write((byte)Gender);
        writer.Write(Hair);
        writer.Write(Level);
        writer.Write(LoverName);
        writer.Write(AllowObserve);
    }
}