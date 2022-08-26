using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class Run : Packet
{
    public override short Index { get { return (short)ClientPacketIds.Run; } }

    public MirDirection Direction;
    public override void ReadPacket(BinaryReader reader)
    {
        Direction = (MirDirection)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Direction);
    }
}