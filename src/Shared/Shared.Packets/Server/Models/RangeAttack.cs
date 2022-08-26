using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class RangeAttack : ServerPacket //ArcherTest
{
    public override short Index { get { return (short)ServerPacketIds.RangeAttack; } }

    public uint TargetID;
    public Point Target;
    public Spell Spell;

    public override void ReadPacket(BinaryReader reader)
    {
        TargetID = reader.ReadUInt32();
        Target = new Point(reader.ReadInt32(), reader.ReadInt32());
        Spell = (Spell)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(TargetID);
        writer.Write(Target.X);
        writer.Write(Target.Y);
        writer.Write((byte)Spell);
    }
}