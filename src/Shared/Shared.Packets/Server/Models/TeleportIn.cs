namespace Shared.Packets.Server.Models;

public sealed class TeleportIn : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.TeleportIn; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}