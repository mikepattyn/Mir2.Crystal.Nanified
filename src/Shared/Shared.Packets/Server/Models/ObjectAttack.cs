using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectAttack : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectAttack; }
    }

    public uint ObjectID;
    public Point Location;
    public MirDirection Direction;
    public Spell Spell;
    public byte Level;
    public byte Type;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
        Spell = (Spell)reader.ReadByte();
        Level = reader.ReadByte();
        Type = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
        writer.Write((byte)Spell);
        writer.Write(Level);
        writer.Write(Type);
    }
}