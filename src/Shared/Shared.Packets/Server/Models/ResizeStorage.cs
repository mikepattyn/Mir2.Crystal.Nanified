namespace Shared.Packets.Server.Models;

public sealed class ResizeStorage : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ResizeStorage; } }

    public int Size;
    public bool HasExpandedStorage;
    public DateTime ExpiryTime;

    public override void ReadPacket(BinaryReader reader)
    {
        Size = reader.ReadInt32();
        HasExpandedStorage = reader.ReadBoolean();
        ExpiryTime = DateTime.FromBinary(reader.ReadInt64());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Size);
        writer.Write(HasExpandedStorage);
        writer.Write(ExpiryTime.ToBinary());
    }
}