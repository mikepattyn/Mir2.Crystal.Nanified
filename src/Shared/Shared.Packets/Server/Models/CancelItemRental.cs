namespace Shared.Packets.Server.Models;

public sealed class CancelItemRental : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.CancelItemRental; }
    }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}