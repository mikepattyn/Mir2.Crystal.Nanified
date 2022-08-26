using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class Pushed : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.Pushed; }
    }

    public Point Location;
    public MirDirection Direction;


    public override void ReadPacket(BinaryReader reader)
    {
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
    }
}