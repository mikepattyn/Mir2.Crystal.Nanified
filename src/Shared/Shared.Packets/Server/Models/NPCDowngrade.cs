namespace Shared.Packets.Server.Models;

public sealed class NPCDowngrade : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCDowngrade; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}