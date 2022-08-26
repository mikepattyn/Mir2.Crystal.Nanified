using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class Attack : Packet
{
    public override short Index { get { return (short)ClientPacketIds.Attack; } }

    public MirDirection Direction;
    public Spell Spell;

    public override void ReadPacket(BinaryReader reader)
    {
        Direction = (MirDirection)reader.ReadByte();
        Spell = (Spell)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Direction);
        writer.Write((byte)Spell);
    }
}