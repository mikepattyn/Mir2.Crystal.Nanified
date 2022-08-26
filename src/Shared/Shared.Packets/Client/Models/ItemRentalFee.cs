﻿namespace Shared.Packets.Client.Models;

public sealed class ItemRentalFee : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ItemRentalFee; } }

    public uint Amount;

    public override void ReadPacket(BinaryReader reader)
    {
        Amount = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Amount);
    }
}