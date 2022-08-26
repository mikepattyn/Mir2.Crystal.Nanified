﻿namespace Shared.Packets.Server.Models;

public sealed class TransferHeroItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.TransferHeroItem; }
    }

    public int From, To;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        From = reader.ReadInt32();
        To = reader.ReadInt32();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(From);
        writer.Write(To);
        writer.Write(Success);
    }
}