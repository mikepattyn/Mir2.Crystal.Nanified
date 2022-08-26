namespace Shared.Packets.Server.Models;

public sealed class NPCStorage : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCStorage; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}