namespace Shared.Packets.Client.Models;

public sealed class LockMail : Packet
{
    public override short Index { get { return (short)ClientPacketIds.LockMail; } }

    public ulong MailID;
    public bool Lock;

    public override void ReadPacket(BinaryReader reader)
    {
        MailID = reader.ReadUInt64();
        Lock = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MailID);
        writer.Write(Lock);
    }
}