namespace Shared.Packets.Server.Models;

public sealed class DeleteGroup : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.DeleteGroup; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}