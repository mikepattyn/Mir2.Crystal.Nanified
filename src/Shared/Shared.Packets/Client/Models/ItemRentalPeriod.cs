namespace Shared.Packets.Client.Models;

public sealed class ItemRentalPeriod : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ItemRentalPeriod; } }

    public uint Days;

    public override void ReadPacket(BinaryReader reader)
    {
        Days = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Days);
    }
}