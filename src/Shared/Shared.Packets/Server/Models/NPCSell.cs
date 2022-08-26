namespace Shared.Packets.Server.Models;

public sealed class NPCSell : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCSell; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}