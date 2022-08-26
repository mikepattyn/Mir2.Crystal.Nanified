using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class SetAutoPotItem : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetAutoPotItem; } }

    public MirGridType Grid;
    public int ItemIndex;
    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        ItemIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(ItemIndex);
    }
}