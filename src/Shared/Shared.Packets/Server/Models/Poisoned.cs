using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class Poisoned : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.Poisoned; } }

    public PoisonType Poison;

    public override void ReadPacket(BinaryReader reader)
    {
        Poison = (PoisonType)reader.ReadUInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((ushort)Poison);
    }
}