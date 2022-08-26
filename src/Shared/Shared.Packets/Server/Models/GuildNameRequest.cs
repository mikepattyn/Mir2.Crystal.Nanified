namespace Shared.Packets.Server.Models;

public sealed class GuildNameRequest : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.GuildNameRequest; } }
    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}