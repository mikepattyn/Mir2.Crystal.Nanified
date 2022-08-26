using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class Awakening : Packet
{
    public override short Index { get { return (short)ClientPacketIds.Awakening; } }

    public ulong UniqueID;
    public AwakeType Type;
    public uint PositionIdx;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Type = (AwakeType)reader.ReadByte();
        PositionIdx = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write((byte)Type);
        writer.Write(PositionIdx);
    }
}