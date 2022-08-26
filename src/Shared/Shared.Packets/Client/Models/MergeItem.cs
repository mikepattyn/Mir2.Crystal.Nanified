using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class MergeItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MergeItem; } }

    public MirGridType GridFrom, GridTo;
    public ulong IDFrom, IDTo;
    public override void ReadPacket(BinaryReader reader)
    {
        GridFrom = (MirGridType)reader.ReadByte();
        GridTo = (MirGridType)reader.ReadByte();
        IDFrom = reader.ReadUInt64();
        IDTo = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)GridFrom);
        writer.Write((byte)GridTo);
        writer.Write(IDFrom);
        writer.Write(IDTo);
    }
}