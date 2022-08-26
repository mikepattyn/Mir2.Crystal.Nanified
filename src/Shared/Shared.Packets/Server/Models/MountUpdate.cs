namespace Shared.Packets.Server.Models;

public sealed class MountUpdate : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MountUpdate; } }

    public long ObjectID;
    public short MountType;
    public bool RidingMount;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadInt64();
        MountType = reader.ReadInt16();
        RidingMount = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(MountType);
        writer.Write(RidingMount);
    }
}