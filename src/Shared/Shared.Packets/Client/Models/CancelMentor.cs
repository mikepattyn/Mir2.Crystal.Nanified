namespace Shared.Packets.Client.Models;

public sealed class CancelMentor : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CancelMentor; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}