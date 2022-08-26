using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class RemoveSlotItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.RemoveSlotItem; }
    }

    public MirGridType Grid;
    public MirGridType GridTo;
    public ulong UniqueID;
    public int To;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        GridTo = (MirGridType)reader.ReadByte();
        UniqueID = reader.ReadUInt64();
        To = reader.ReadInt32();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write((byte)GridTo);
        writer.Write(UniqueID);
        writer.Write(To);
        writer.Write(Success);
    }
}