using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class SpellToggle : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SpellToggle; } }
    public Spell Spell;
    public SpellToggleState canUse = SpellToggleState.None;
    public bool CanUse
    {
        get { return Convert.ToBoolean(canUse); }
        set
        {
            canUse = (SpellToggleState)Convert.ToSByte(value);
        }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        Spell = (Spell)reader.ReadByte();
        canUse = (SpellToggleState)reader.ReadSByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Spell);
        writer.Write((sbyte)canUse);
    }
}