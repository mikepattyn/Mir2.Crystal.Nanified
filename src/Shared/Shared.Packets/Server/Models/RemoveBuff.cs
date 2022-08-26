using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class RemoveBuff : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.RemoveBuff; } }

    public BuffType Type;
    public uint ObjectID;

    public override void ReadPacket(BinaryReader reader)
    {
        Type = (BuffType)reader.ReadByte();
        ObjectID = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Type);
        writer.Write(ObjectID);
    }
}