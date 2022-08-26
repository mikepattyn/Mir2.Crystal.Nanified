namespace Shared.Packets.Client.Models;

public sealed class ChangeMarriage : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ChangeMarriage; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}