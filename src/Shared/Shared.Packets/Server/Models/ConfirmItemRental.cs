namespace Shared.Packets.Server.Models;

public sealed class ConfirmItemRental : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ConfirmItemRental; }
    }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}