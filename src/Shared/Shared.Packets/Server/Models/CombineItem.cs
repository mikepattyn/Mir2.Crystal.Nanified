using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class CombineItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.CombineItem; }
    }

    public MirGridType Grid;
    public ulong IDFrom, IDTo;
    public bool Success;
    public bool Destroy;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        IDFrom = reader.ReadUInt64();
        IDTo = reader.ReadUInt64();
        Success = reader.ReadBoolean();
        Destroy = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(IDFrom);
        writer.Write(IDTo);
        writer.Write(Success);
        writer.Write(Destroy);
    }
}