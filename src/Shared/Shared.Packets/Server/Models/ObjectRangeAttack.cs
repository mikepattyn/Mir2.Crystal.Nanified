using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectRangeAttack : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectRangeAttack; }
    }

    public uint ObjectID;
    public Point Location;
    public MirDirection Direction;
    public uint TargetID;
    public Point Target;
    public byte Type;
    public Spell Spell;
    public byte Level;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
        TargetID = reader.ReadUInt32();
        Target = new Point(reader.ReadInt32(), reader.ReadInt32());
        Type = reader.ReadByte();
        Spell = (Spell)reader.ReadByte();
        Level = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
        writer.Write(TargetID);
        writer.Write(Target.X);
        writer.Write(Target.Y);
        writer.Write(Type);
        writer.Write((byte)Spell);
        writer.Write(Level);
    }
}