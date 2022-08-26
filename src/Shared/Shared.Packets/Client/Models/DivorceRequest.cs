namespace Shared.Packets.Client.Models;

public sealed class DivorceRequest : Packet
{
    public override short Index { get { return (short)ClientPacketIds.DivorceRequest; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}