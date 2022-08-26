namespace Shared.Packets.Server.Models;

public sealed class ObjectMana : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectMana; } }
    public uint ObjectID;
    public byte Percent;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Percent = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Percent);
    }
}