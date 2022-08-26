﻿using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class ItemUpgraded : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ItemUpgraded; }
    }

    public UserItem Item;

    public override void ReadPacket(BinaryReader reader)
    {
        Item = new UserItem(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Item.Save(writer);
    }
}