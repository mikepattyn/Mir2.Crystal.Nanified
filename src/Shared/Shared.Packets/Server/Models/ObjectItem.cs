using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectItem; }
    }

    public uint ObjectID;
    public string Name = string.Empty;
    public Color NameColour;
    public Point Location;
    public ushort Image;
    public ItemGrade grade;


    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
        NameColour = Color.FromArgb(reader.ReadInt32());
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Image = reader.ReadUInt16();
        grade = (ItemGrade)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
        writer.Write(NameColour.ToArgb());
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(Image);
        writer.Write((byte)grade);
    }
}