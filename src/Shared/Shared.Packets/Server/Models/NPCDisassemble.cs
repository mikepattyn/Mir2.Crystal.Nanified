﻿namespace Shared.Packets.Server.Models;

public sealed class NPCDisassemble : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCDisassemble; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}