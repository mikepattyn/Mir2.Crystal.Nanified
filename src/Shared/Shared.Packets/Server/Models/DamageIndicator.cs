using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class DamageIndicator : ServerPacket
{
    public int Damage;
    public DamageType Type;
    public uint ObjectID;

    public override short Index
    {
        get { return (short)ServerPacketIds.DamageIndicator; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        Damage = reader.ReadInt32();
        Type = (DamageType)reader.ReadByte();
        ObjectID = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Damage);
        writer.Write((byte)Type);
        writer.Write(ObjectID);
    }
}