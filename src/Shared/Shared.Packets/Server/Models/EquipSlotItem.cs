using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class EquipSlotItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.EquipSlotItem; }
    }

    public MirGridType Grid;
    public ulong UniqueID;
    public int To;
    public bool Success;
    public MirGridType GridTo;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        UniqueID = reader.ReadUInt64();
        To = reader.ReadInt32();
        GridTo = (MirGridType)reader.ReadByte();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(UniqueID);
        writer.Write(To);
        writer.Write((byte)GridTo);
        writer.Write(Success);
    }
}