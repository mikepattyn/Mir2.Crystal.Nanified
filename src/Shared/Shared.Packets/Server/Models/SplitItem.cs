using Shared.Enums;
using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class SplitItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.SplitItem; }
    }

    public UserItem Item;
    public MirGridType Grid;

    public override void ReadPacket(BinaryReader reader)
    {
        if (reader.ReadBoolean())
            Item = new UserItem(reader);

        Grid = (MirGridType)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Item != null);
        if (Item != null) Item.Save(writer);
        writer.Write((byte)Grid);
    }
}