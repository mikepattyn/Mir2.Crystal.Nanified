using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectNPC : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectNpc; }
    }

    public uint ObjectID;
    public string Name = string.Empty;

    public Color NameColour;
    public ushort Image;
    public Color Colour;
    public Point Location;
    public MirDirection Direction;
    public List<int> QuestIDs = new List<int>();

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
        NameColour = Color.FromArgb(reader.ReadInt32());
        Image = reader.ReadUInt16();
        Colour = Color.FromArgb(reader.ReadInt32());
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();

        int count = reader.ReadInt32();

        for (var i = 0; i < count; i++)
            QuestIDs.Add(reader.ReadInt32());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
        writer.Write(NameColour.ToArgb());
        writer.Write(Image);
        writer.Write(Colour.ToArgb());
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);

        writer.Write(QuestIDs.Count);

        for (int i = 0; i < QuestIDs.Count; i++)
            writer.Write(QuestIDs[i]);
    }
}