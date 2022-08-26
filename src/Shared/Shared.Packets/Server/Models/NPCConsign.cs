namespace Shared.Packets.Server.Models;

public sealed class NPCConsign : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCConsign; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}