using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class NewItemInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewItemInfo; }
    }

    public ItemInfo Info;

    public override void ReadPacket(BinaryReader reader)
    {
        Info = new ItemInfo(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Info.Save(writer);
    }
}