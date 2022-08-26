using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class TradeItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.TradeItem; }
    }

    public UserItem[] TradeItems;

    public override void ReadPacket(BinaryReader reader)
    {
        TradeItems = new UserItem[reader.ReadInt32()];
        for (int i = 0; i < TradeItems.Length; i++)
        {
            if (reader.ReadBoolean())
                TradeItems[i] = new UserItem(reader);
        }
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(TradeItems.Length);
        for (int i = 0; i < TradeItems.Length; i++)
        {
            UserItem T = TradeItems[i];
            writer.Write(T != null);
            if (T != null) T.Save(writer);
        }
    }
}