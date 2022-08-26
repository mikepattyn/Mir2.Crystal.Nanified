using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class MagicLeveled : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MagicLeveled; }
    }

    public uint ObjectID;
    public Spell Spell;
    public byte Level;
    public ushort Experience;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Spell = (Spell)reader.ReadByte();
        Level = reader.ReadByte();
        Experience = reader.ReadUInt16();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((byte)Spell);
        writer.Write(Level);
        writer.Write(Experience);
    }
}