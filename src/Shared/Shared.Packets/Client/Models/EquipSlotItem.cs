using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class EquipSlotItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.EquipSlotItem; } }

    public MirGridType Grid;
    public ulong UniqueID;
    public int To;
    public MirGridType GridTo;
    public ulong ToUniqueID;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        UniqueID = reader.ReadUInt64();
        To = reader.ReadInt32();
        GridTo = (MirGridType)reader.ReadByte();
        ToUniqueID = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(UniqueID);
        writer.Write(To);
        writer.Write((byte)GridTo);
        writer.Write(ToUniqueID);
    }
}