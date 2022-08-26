using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class BuyItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.BuyItem; } }

    public ulong ItemIndex;
    public ushort Count;
    public PanelType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        ItemIndex = reader.ReadUInt64();
        Count = reader.ReadUInt16();
        Type = (PanelType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ItemIndex);
        writer.Write(Count);
        writer.Write((byte)Type);
    }
}