using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class UseItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UseItem; }
    }

    public ulong UniqueID;
    public bool Success;
    public MirGridType Grid;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Success = reader.ReadBoolean();
        Grid = (MirGridType)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Success);
        writer.Write((byte)Grid);
    }
}