namespace Shared.Packets.Server.Models;

public sealed class NPCReset : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCReset; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}