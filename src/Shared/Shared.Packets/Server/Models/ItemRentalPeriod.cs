namespace Shared.Packets.Server.Models;

public sealed class ItemRentalPeriod : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ItemRentalPeriod; }
    }

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