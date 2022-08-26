using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class AwakeningNeedMaterials : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AwakeningNeedMaterials; } }

    public ulong UniqueID;
    public AwakeType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Type = (AwakeType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write((byte)Type);
    }
}