using Shared.Models.Guild;
using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class GuildStorageItemChange : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.GuildStorageItemChange; } }
    public int User = 0;
    public byte Type = 0;
    public int To = 0;
    public int From = 0;
    public GuildStorageItem Item = null;
    public override void ReadPacket(BinaryReader reader)
    {
        Type = reader.ReadByte();
        To = reader.ReadInt32();
        From = reader.ReadInt32();
        User = reader.ReadInt32();
        if (!reader.ReadBoolean()) return;
        Item = new GuildStorageItem
        {
            UserId = reader.ReadInt64(),
            Item = new UserItem(reader)
        };
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Type);
        writer.Write(To);
        writer.Write(From);
        writer.Write(User);
        writer.Write(Item != null);
        if (Item == null) return;
        writer.Write(Item.UserId);
        Item.Item.Save(writer);
    }
}