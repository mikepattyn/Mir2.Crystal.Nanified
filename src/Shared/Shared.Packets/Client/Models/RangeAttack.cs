using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Client.Models;

public sealed class RangeAttack : Packet //ArcherTest
{
    public override short Index { get { return (short)ClientPacketIds.RangeAttack; } }

    public MirDirection Direction;
    public Point Location;
    public uint TargetID;
    public Point TargetLocation;

    public override void ReadPacket(BinaryReader reader)
    {
        Direction = (MirDirection)reader.ReadByte();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        TargetID = reader.ReadUInt32();
        TargetLocation = new Point(reader.ReadInt32(), reader.ReadInt32());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Direction);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(TargetID);
        writer.Write(TargetLocation.X);
        writer.Write(TargetLocation.Y);
    }
}