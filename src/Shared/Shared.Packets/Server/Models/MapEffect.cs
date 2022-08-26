using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class MapEffect : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MapEffect; } }

    public Point Location;
    public SpellEffect Effect;
    public byte Value;

    public override void ReadPacket(BinaryReader reader)
    {
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Effect = (SpellEffect)reader.ReadByte();
        Value = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Effect);
        writer.Write(Value);
    }
}