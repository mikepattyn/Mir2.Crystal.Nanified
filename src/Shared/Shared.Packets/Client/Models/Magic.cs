using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Client.Models;

public sealed class Magic : Packet
{
    public override short Index { get { return (short)ClientPacketIds.Magic; } }

    public Spell Spell;
    public MirDirection Direction;
    public uint TargetID;
    public Point Location;
    public uint ObjectID;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Spell = (Spell)reader.ReadByte();
        Direction = (MirDirection)reader.ReadByte();
        TargetID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((byte)Spell);
        writer.Write((byte)Direction);
        writer.Write(TargetID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
    }
}