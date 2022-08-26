using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class ConsignItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ConsignItem; } }

    public ulong UniqueID;
    public uint Price;
    public MarketPanelType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Price = reader.ReadUInt32();
        Type = (MarketPanelType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Price);
        writer.Write((byte)Type);
    }
}