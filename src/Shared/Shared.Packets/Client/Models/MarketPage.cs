namespace Shared.Packets.Client.Models;

public sealed class MarketPage : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MarketPage; } }
    public int Page;

    public override void ReadPacket(BinaryReader reader)
    {
        Page = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Page);
    }
}