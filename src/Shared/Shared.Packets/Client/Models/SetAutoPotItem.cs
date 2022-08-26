using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class SetAutoPotItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SetAutoPotItem; } }

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