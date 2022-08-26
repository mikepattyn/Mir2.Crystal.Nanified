namespace Shared.Packets.Client.Models;

public sealed class MarketSellNow : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MarketSellNow; } }

    public ulong AuctionID;

    public override void ReadPacket(BinaryReader reader)
    {
        AuctionID = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AuctionID);
    }
}