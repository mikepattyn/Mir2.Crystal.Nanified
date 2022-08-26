using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class PauseBuff : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.PauseBuff; } }

    public BuffType Type;
    public uint ObjectID;
    public bool Paused;

    public override void ReadPacket(BinaryReader reader)
    {
        Type = (BuffType)reader.ReadByte();
        ObjectID = reader.ReadUInt32();
        Paused = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Type);
        writer.Write(ObjectID);
        writer.Write(Paused);
    }
}