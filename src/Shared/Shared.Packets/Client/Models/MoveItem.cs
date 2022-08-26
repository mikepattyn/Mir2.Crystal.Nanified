using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class MoveItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MoveItem; } }

    public MirGridType Grid;
    public int From, To;
    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        From = reader.ReadInt32();
        To = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(From);
        writer.Write(To);
    }
}