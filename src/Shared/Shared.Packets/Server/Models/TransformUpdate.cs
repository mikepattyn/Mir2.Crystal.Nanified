namespace Shared.Packets.Server.Models;

public sealed class TransformUpdate : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.TransformUpdate; } }

    public long ObjectID;
    public short TransformType;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadInt64();
        TransformType = reader.ReadInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(TransformType);
    }
}