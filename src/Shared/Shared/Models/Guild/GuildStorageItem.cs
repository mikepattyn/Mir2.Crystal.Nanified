using Shared.Models.Items;

namespace Shared.Models.Guild;

public class GuildStorageItem
{
    public UserItem Item;
    public long UserId = 0;
    public GuildStorageItem() { }

    public GuildStorageItem(BinaryReader reader)
    {
        Item = new UserItem(reader);
        UserId = reader.ReadInt64();
    }
    public void Save(BinaryWriter writer)
    {
        Item.Save(writer);
        writer.Write(UserId);
    }
}