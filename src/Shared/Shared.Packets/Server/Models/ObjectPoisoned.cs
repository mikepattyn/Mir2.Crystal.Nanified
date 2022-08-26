using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ObjectPoisoned : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectPoisoned; } }

    public uint ObjectID;
    public PoisonType Poison;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Poison = (PoisonType)reader.ReadUInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((ushort)Poison);
    }
}