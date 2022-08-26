namespace Shared.Packets.Client.Models;

public sealed class CancelReincarnation : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CancelReincarnation; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}