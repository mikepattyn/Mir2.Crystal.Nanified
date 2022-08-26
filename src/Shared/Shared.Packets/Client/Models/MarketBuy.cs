namespace Shared.Packets.Client.Models;

public sealed class MarketBuy : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MarketBuy; } }

    public ulong AuctionID;
    public uint BidPrice;

    public override void ReadPacket(BinaryReader reader)
    {
        AuctionID = reader.ReadUInt64();
        BidPrice = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AuctionID);
        writer.Write(BidPrice);
    }
}