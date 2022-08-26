using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectDeco : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectDeco; }
    }

    public uint ObjectID;
    public Point Location;
    public int Image;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Image = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(Image);
    }
}