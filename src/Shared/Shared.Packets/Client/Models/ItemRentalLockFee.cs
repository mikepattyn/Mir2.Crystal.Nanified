namespace Shared.Packets.Client.Models;

public sealed class ItemRentalLockFee : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ItemRentalLockFee; } }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}