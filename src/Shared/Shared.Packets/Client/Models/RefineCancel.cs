namespace Shared.Packets.Client.Models;

public sealed class RefineCancel : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RefineCancel; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}