using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectGold : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectGold; }
    }

    public uint ObjectID;
    public uint Gold;
    public Point Location;


    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Gold = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Gold);
        writer.Write(Location.X);
        writer.Write(Location.Y);
    }
}