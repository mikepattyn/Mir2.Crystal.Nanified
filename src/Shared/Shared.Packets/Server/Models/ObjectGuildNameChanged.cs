namespace Shared.Packets.Server.Models;

public sealed class ObjectGuildNameChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectGuildNameChanged; }
    }

    public uint ObjectID;
    public string GuildName;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        GuildName = reader.ReadString();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(GuildName);
    }
}