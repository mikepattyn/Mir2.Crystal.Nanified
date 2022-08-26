namespace Shared.Packets.Server.Models;

public sealed class DropItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.DropItem; }
    }

    public ulong UniqueID;
    public ushort Count;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Count = reader.ReadUInt16();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Count);
        writer.Write(Success);
    }
}