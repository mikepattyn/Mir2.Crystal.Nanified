namespace Shared.Packets.Server.Models;

public sealed class ObjectHidden : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectHidden; } }
    public uint ObjectID;
    public bool Hidden;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Hidden = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Hidden);
    }
}