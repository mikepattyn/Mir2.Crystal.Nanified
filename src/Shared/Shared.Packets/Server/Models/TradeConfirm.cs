namespace Shared.Packets.Server.Models;

public sealed class TradeConfirm : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.TradeConfirm; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}