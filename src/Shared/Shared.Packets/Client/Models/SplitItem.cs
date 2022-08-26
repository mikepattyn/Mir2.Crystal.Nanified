using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class SplitItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SplitItem; } }

    public MirGridType Grid;
    public ulong UniqueID;
    public ushort Count;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        UniqueID = reader.ReadUInt64();
        Count = reader.ReadUInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(UniqueID);
        writer.Write(Count);
    }
}