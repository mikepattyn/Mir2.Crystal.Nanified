namespace Shared.Packets.Server.Models;

public sealed class ReturnToLogin : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ReturnToLogin; }
    }

    public override bool Observable => false;

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}