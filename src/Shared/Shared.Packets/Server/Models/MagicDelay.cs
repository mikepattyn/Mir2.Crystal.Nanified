using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class MagicDelay : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MagicDelay; } }

    public uint ObjectID;
    public Spell Spell;
    public long Delay;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Spell = (Spell)reader.ReadByte();
        Delay = reader.ReadInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((byte)Spell);
        writer.Write(Delay);
    }
}