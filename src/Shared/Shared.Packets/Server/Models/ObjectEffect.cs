using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ObjectEffect : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectEffect; } }

    public uint ObjectID;
    public SpellEffect Effect;
    public uint EffectType;
    public uint DelayTime = 0;
    public uint Time = 0;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Effect = (SpellEffect)reader.ReadByte();
        EffectType = reader.ReadUInt32();
        DelayTime = reader.ReadUInt32();
        Time = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((byte)Effect);
        writer.Write(EffectType);
        writer.Write(DelayTime);
        writer.Write(Time);
    }
}