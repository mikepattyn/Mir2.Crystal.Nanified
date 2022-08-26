namespace Shared.Packets.Client.Models;

public sealed class MarriageRequest : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MarriageRequest; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}