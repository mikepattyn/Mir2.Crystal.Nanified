namespace Shared.Packets.Server.Models;

public sealed class GameShopStock : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GameShopStock; }
    }

    public int GIndex;
    public int StockLevel;

    public override void ReadPacket(BinaryReader reader)
    {
        GIndex = reader.ReadInt32();
        StockLevel = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(GIndex);
        writer.Write(StockLevel);
    }
}