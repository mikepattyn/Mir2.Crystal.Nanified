namespace Shared.Packets.Server.Models;

public sealed class CancelReincarnation : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.CancelReincarnation; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}