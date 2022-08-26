﻿namespace Shared.Packets.Server.Models;

public sealed class TradeGold : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.TradeGold; }
    }

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