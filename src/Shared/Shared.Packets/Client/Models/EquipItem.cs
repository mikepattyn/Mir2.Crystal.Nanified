using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class EquipItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.EquipItem; } }

    public MirGridType Grid;
    public ulong UniqueID;
    public int To;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        UniqueID = reader.ReadUInt64();
        To = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(UniqueID);
        writer.Write(To);
    }
}