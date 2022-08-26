namespace Shared.Packets.Server.Models;

public sealed class MailSendRequest : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MailSendRequest; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}