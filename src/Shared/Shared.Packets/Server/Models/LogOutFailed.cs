namespace Shared.Packets.Server.Models;

public sealed class LogOutFailed : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.LogOutFailed; }
    }

    public override bool Observable => false;

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}