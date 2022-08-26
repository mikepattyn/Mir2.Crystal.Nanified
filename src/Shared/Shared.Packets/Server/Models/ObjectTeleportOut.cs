namespace Shared.Packets.Server.Models;

public sealed class ObjectTeleportOut : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectTeleportOut; } }

    public uint ObjectID;
    public byte Type;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Type = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Type);
    }
}