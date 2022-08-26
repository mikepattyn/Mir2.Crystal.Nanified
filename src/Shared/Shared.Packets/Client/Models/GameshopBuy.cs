namespace Shared.Packets.Client.Models;

public sealed class GameshopBuy : Packet
{
    public override short Index { get { return (short)ClientPacketIds.GameshopBuy; } }

    public int GIndex;
    public byte Quantity;

    public override void ReadPacket(BinaryReader reader)
    {
        GIndex = reader.ReadInt32();
        Quantity = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(GIndex);
        writer.Write(Quantity);
    }
}