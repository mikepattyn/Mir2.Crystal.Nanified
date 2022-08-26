using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class MagicKey : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MagicKey; } }

    public Spell Spell;
    public byte Key, OldKey;

    public override void ReadPacket(BinaryReader reader)
    {
        Spell = (Spell)reader.ReadByte();
        Key = reader.ReadByte();
        OldKey = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Spell);
        writer.Write(Key);
        writer.Write(OldKey);
    }
}