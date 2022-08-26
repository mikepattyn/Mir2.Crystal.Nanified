namespace Shared.Packets.Server.Models;

public sealed class ObjectTeleportIn : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectTeleportIn; } }

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