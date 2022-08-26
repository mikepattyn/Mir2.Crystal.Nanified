namespace Shared.Packets.Client.Models;

public sealed class TradeConfirm : Packet
{
    public override short Index { get { return (short)ClientPacketIds.TradeConfirm; } }

    public bool Locked;
    public override void ReadPacket(BinaryReader reader)
    {
        Locked = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Locked);
    }
}