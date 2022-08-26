namespace Shared.Packets.Server.Models;

public sealed class ObjectHealth : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectHealth; } }
    public uint ObjectID;
    public byte Percent, Expire;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Percent = reader.ReadByte();
        Expire = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Percent);
        writer.Write(Expire);
    }
}