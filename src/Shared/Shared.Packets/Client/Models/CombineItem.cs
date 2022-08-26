using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class CombineItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CombineItem; } }

    public MirGridType Grid;
    public ulong IDFrom, IDTo;
    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        IDFrom = reader.ReadUInt64();
        IDTo = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(IDFrom);
        writer.Write(IDTo);
    }
}