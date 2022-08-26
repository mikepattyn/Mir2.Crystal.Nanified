namespace Shared.Packets.Server.Models;

public sealed class MarketFail : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MarketFail; } }

    public byte Reason;

    /*
     * 0: Dead.
     * 1: Not talking to TrustMerchant.
     * 2: Already Sold.
     * 3: Expired.
     * 4: Not enough Gold.
     * 5: Too heavy or not enough bag space.
     * 6: You cannot buy your own items.
     * 7: Trust Merchant is too far.
     * 8: Too much Gold.
     */

    public override void ReadPacket(BinaryReader reader)
    {
        Reason = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Reason);
    }
}