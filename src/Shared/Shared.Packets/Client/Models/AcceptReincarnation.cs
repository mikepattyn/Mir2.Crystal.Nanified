namespace Shared.Packets.Client.Models;

public sealed class AcceptReincarnation : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AcceptReincarnation; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}