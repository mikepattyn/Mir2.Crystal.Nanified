using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class SplitItem1 : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.SplitItem1; }
    }

    public MirGridType Grid;
    public ulong UniqueID;
    public ushort Count;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        UniqueID = reader.ReadUInt64();
        Count = reader.ReadUInt16();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(UniqueID);
        writer.Write(Count);
        writer.Write(Success);
    }
}