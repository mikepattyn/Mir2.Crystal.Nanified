namespace Shared.Packets.Server.Models;

public sealed class GuildRequestWar : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.GuildRequestWar; } }
    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}