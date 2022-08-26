using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class UseItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.UseItem; } }

    public ulong UniqueID;
    public MirGridType Grid;
    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Grid = (MirGridType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write((byte)Grid);
    }
}