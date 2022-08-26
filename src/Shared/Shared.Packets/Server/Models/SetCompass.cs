using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class SetCompass : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetCompass; } }

    public Point Location;

    public override void ReadPacket(BinaryReader reader)
    {
        var x = reader.ReadInt32();
        var y = reader.ReadInt32();

        Location = new Point(x, y);
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Location.X);
        writer.Write(Location.Y);
    }
}