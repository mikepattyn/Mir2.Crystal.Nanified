namespace Shared.Packets.Client.Models;

public sealed class AwakeningLockedItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AwakeningLockedItem; } }

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