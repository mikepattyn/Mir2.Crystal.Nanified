using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class SpellToggle : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SpellToggle; } }
    public uint ObjectID;
    public Spell Spell;
    public bool CanUse;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Spell = (Spell)reader.ReadByte();
        CanUse = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((byte)Spell);
        writer.Write(CanUse);
    }
}