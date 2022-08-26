using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectColourChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectColourChanged; }
    }

    public uint ObjectID;
    public Color NameColour;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        NameColour = Color.FromArgb(reader.ReadInt32());
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(NameColour.ToArgb());
    }
}