namespace Shared.Packets.Server.Models;

public sealed class NPCAwakening : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCAwakening; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}