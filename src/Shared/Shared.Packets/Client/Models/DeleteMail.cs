namespace Shared.Packets.Client.Models;

public sealed class DeleteMail : Packet
{
    public override short Index { get { return (short)ClientPacketIds.DeleteMail; } }

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