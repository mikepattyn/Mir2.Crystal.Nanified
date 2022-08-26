namespace Shared.Packets.Server.Models;

public sealed class ResizeInventory : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ResizeInventory; } }

    public int Size;

    public override void ReadPacket(BinaryReader reader)
    {
        Size = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Size);
    }
}