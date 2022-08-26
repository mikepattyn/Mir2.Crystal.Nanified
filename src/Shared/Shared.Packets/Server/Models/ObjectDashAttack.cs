using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectDashAttack : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectDashAttack; }
    }

    public uint ObjectID;
    public Point Location;
    public MirDirection Direction;
    public int Distance;


    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
        Distance = reader.ReadInt16();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
        writer.Write(Distance);
    }
}