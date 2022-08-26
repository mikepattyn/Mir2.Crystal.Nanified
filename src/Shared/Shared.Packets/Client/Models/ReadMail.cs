namespace Shared.Packets.Client.Models;

public sealed class ReadMail : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ReadMail; } }

    public ulong MailID;

    public override void ReadPacket(BinaryReader reader)
    {
        MailID = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MailID);
    }
}