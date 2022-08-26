using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class MoveItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MoveItem; }
    }

    public MirGridType Grid;
    public int From, To;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        Grid = (MirGridType)reader.ReadByte();
        From = reader.ReadInt32();
        To = reader.ReadInt32();
        Success = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Grid);
        writer.Write(From);
        writer.Write(To);
        writer.Write(Success);
    }
}