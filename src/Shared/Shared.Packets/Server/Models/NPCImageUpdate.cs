using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class NPCImageUpdate : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCImageUpdate; } }

    public long ObjectID;
    public ushort Image;
    public Color Colour;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadInt64();
        Image = reader.ReadUInt16();
        Colour = Color.FromArgb(reader.ReadInt32());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Image);
        writer.Write(Colour.ToArgb());
    }
}