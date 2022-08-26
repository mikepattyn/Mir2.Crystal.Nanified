namespace Shared.Packets.Server.Models;

public sealed class MailLockedItem : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MailLockedItem; } }

    public ulong UniqueID;
    public bool Locked;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Locked = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Locked);
    }
}