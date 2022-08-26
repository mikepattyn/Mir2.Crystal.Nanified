using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class GuildStatus : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GuildStatus; }
    }
    public string GuildName = string.Empty;
    public string GuildRankName = string.Empty;
    public byte Level;
    public long Experience;
    public long MaxExperience;
    public uint Gold;
    public byte SparePoints;
    public int MemberCount;
    public int MaxMembers;
    public bool Voting;
    public byte ItemCount;
    public byte BuffCount;
    public GuildRankOptions MyOptions;
    public int MyRankId;

    public override void ReadPacket(BinaryReader reader)
    {
        GuildName = reader.ReadString();
        GuildRankName = reader.ReadString();
        Level = reader.ReadByte();
        Experience = reader.ReadInt64();
        MaxExperience = reader.ReadInt64();
        Gold = reader.ReadUInt32();
        SparePoints = reader.ReadByte();
        MemberCount = reader.ReadInt32();
        MaxMembers = reader.ReadInt32();
        Voting = reader.ReadBoolean();
        ItemCount = reader.ReadByte();
        BuffCount = reader.ReadByte();
        MyOptions = (GuildRankOptions)reader.ReadByte();
        MyRankId = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(GuildName);
        writer.Write(GuildRankName);
        writer.Write(Level);
        writer.Write(Experience);
        writer.Write(MaxExperience);
        writer.Write(Gold);
        writer.Write(SparePoints);
        writer.Write(MemberCount);
        writer.Write(MaxMembers);
        writer.Write(Voting);
        writer.Write(ItemCount);
        writer.Write(BuffCount);
        writer.Write((byte)MyOptions);
        writer.Write(MyRankId);
    }
}