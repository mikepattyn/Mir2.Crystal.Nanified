namespace Shared.Packets.Server.Models;

public sealed class MailSent : ServerPacket
{
    public sbyte Result;

    public override short Index
    {
        get { return (short)ServerPacketIds.MailSent; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadSByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }
}