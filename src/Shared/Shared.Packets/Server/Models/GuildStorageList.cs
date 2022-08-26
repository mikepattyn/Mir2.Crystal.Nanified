using Shared.Models.Guild;

namespace Shared.Packets.Server.Models;

public sealed class GuildStorageList : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GuildStorageList; }
    }
    public GuildStorageItem[] Items;
    public override void ReadPacket(BinaryReader reader)
    {
        Items = new GuildStorageItem[reader.ReadInt32()];
        for (int i = 0; i < Items.Length; i++)
        {
            if (reader.ReadBoolean() == true)
                Items[i] = new GuildStorageItem(reader);
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Items.Length);
        for (int i = 0; i < Items.Length; i++)
        {
            writer.Write(Items[i] != null);
            if (Items[i] != null)
                Items[i].Save(writer);
        }
    }

}