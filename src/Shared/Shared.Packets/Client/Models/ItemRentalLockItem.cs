﻿namespace Shared.Packets.Client.Models;

public sealed class ItemRentalLockItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ItemRentalLockItem; } }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}