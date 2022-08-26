namespace Shared.Packets.Server.Models;

public sealed class CanConfirmItemRental : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.CanConfirmItemRental; }
    }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}