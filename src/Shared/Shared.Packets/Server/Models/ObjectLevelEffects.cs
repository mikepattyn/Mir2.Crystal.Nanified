using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ObjectLevelEffects : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectLevelEffects; } }

    public uint ObjectID;
    public LevelEffects LevelEffects;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        LevelEffects = (LevelEffects)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write((byte)LevelEffects);
    }
}