using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectStruck : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectStruck; }
    }

    public uint ObjectID;
    public uint AttackerID;
    public Point Location;
    public MirDirection Direction;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        AttackerID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(AttackerID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
    }
}