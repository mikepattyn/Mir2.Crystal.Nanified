using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class MergeItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MergeItem; }
    }

    public MirGridType GridFrom, GridTo;
    public ulong IDFrom, IDTo;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        GridFrom = (MirGridType)reader.ReadByte();
        GridTo = (MirGridType)reader.ReadByte();
        IDFrom = reader.ReadUInt64();
        IDTo = reader.ReadUInt64();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)GridFrom);
        writer.Write((byte)GridTo);
        writer.Write(IDFrom);
        writer.Write(IDTo);
        writer.Write(Success);
    }
}