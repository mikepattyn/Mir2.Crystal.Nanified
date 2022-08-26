namespace Shared.Packets.Client.Models;

public sealed class TownRevive : Packet
{
    public override short Index { get { return (short)ClientPacketIds.TownRevive; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}