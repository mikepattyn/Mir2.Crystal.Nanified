using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class MagicCast : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MagicCast; } }

    public Spell Spell;

    public override void ReadPacket(BinaryReader reader)
    {
        Spell = (Spell)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Spell);
    }
}