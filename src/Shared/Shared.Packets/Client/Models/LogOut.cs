namespace Shared.Packets.Client.Models;

public sealed class LogOut : Packet
{
    public override short Index { get { return (short)ClientPacketIds.LogOut; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}