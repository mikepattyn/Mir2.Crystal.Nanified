namespace Shared.Packets.Client.Models;

public sealed class ItemRentalRequest : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ItemRentalRequest; } }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}