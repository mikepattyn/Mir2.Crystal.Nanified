﻿namespace Shared.Packets.Server.Models;

public sealed class LoseGold : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.LoseGold; }
    }

    public uint Gold;

    public override void ReadPacket(BinaryReader reader)
    {
        Gold = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Gold);
    }
}