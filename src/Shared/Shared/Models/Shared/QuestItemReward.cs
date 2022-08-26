using Shared.Models.Items;

namespace Shared.Models.Shared;

public class QuestItemReward
{
    public ItemInfo Item;
    public ushort Count = 1;

    public QuestItemReward() { }

    public QuestItemReward(BinaryReader reader)
    {
        Item = new ItemInfo(reader);
        Count = reader.ReadUInt16();
    }

    public void Save(BinaryWriter writer)
    {
        Item.Save(writer);
        writer.Write(Count);
    }
}