namespace Shared.Packets.Client.Models;

public sealed class PickUp : Packet
{
    public override short Index { get { return (short)ClientPacketIds.PickUp; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}