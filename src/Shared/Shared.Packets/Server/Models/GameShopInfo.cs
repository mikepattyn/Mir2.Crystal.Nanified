using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class GameShopInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GameShopInfo; }
    }

    public GameShopItem Item;
    public int StockLevel;

    public override void ReadPacket(BinaryReader reader)
    {
        Item = new GameShopItem(reader, true);
        StockLevel = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Item.Save(writer, true);
        writer.Write(StockLevel);
    }
}