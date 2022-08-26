namespace Shared.Packets.Server.Models;

public sealed class ItemSlotSizeChanged : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ItemSlotSizeChanged; } }

    public ulong UniqueID;
    public int SlotSize;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        SlotSize = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(SlotSize);
    }
}