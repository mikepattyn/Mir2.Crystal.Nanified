namespace Shared.Packets.Client.Models;

public sealed class SellItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SellItem; } }

    public ulong UniqueID;
    public ushort Count;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Count = reader.ReadUInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Count);
    }
}