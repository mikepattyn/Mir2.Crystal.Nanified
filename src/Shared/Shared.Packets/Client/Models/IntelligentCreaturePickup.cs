using System.Drawing;

namespace Shared.Packets.Client.Models;

public sealed class IntelligentCreaturePickup : Packet
{
    public override short Index { get { return (short)ClientPacketIds.IntelligentCreaturePickup; } }

    public bool MouseMode = false;
    public Point Location = new Point(0, 0);

    public override void ReadPacket(BinaryReader reader)
    {
        MouseMode = reader.ReadBoolean();
        Location.X = reader.ReadInt32();
        Location.Y = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MouseMode);
        writer.Write(Location.X);
        writer.Write(Location.Y);
    }
}