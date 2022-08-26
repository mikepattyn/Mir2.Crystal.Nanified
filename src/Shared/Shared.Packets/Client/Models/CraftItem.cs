namespace Shared.Packets.Client.Models;

public sealed class CraftItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CraftItem; } }

    public ulong UniqueID;
    public ushort Count;
    public int[] Slots;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Count = reader.ReadUInt16();

        Slots = new int[reader.ReadInt32()];
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i] = reader.ReadInt32();
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Count);

        writer.Write(Slots.Length);
        for (int i = 0; i < Slots.Length; i++)
        {
            writer.Write(Slots[i]);
        }
    }
}