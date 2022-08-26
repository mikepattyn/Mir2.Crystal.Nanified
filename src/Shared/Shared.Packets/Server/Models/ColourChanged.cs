using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ColourChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ColourChanged; }
    }

    public Color NameColour;

    public override void ReadPacket(BinaryReader reader)
    {
        NameColour = Color.FromArgb(reader.ReadInt32());
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(NameColour.ToArgb());
    }
}