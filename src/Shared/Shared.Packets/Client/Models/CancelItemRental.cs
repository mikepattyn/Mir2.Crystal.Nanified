namespace Shared.Packets.Client.Models;

public sealed class CancelItemRental : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CancelItemRental; } }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}