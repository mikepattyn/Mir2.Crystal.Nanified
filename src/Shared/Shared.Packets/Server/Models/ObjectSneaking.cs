namespace Shared.Packets.Server.Models;

public sealed class ObjectSneaking : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectSneaking; } }
    public uint ObjectID;
    public bool SneakingActive;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        SneakingActive = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(SneakingActive);
    }
}