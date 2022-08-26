using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectSpell : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectSpell; }
    }

    public uint ObjectID;
    public Point Location;
    public Spell Spell;
    public MirDirection Direction;
    public bool Param;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Spell = (Spell)reader.ReadByte();
        Direction = (MirDirection)reader.ReadByte();
        Param = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Spell);
        writer.Write((byte)Direction);
        writer.Write(Param);
    }
}