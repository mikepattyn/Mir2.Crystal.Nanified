using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ObjectProjectile : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectProjectile; } }

    public Spell Spell;
    public uint Source;
    public uint Destination;

    public override void ReadPacket(BinaryReader reader)
    {
        Spell = (Spell)reader.ReadByte();
        Source = reader.ReadUInt32();
        Destination = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Spell);
        writer.Write(Source);
        writer.Write(Destination);
    }
}