namespace Shared.Packets.Server.Models;

public sealed class ObjectName : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectName; } }

    public uint ObjectID;
    public string Name = string.Empty;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
    }
}