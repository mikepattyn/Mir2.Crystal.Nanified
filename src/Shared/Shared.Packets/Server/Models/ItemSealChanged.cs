namespace Shared.Packets.Server.Models;

public sealed class ItemSealChanged : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ItemSealChanged; } }

    public ulong UniqueID;
    public DateTime ExpiryDate;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        ExpiryDate = DateTime.FromBinary(reader.ReadInt64());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(ExpiryDate.ToBinary());
    }
}