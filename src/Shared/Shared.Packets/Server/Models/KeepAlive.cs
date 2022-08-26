namespace Shared.Packets.Server.Models;

public sealed class KeepAlive : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.KeepAlive; }
    }
    public long Time;

    public override void ReadPacket(BinaryReader reader)
    {
        Time = reader.ReadInt64();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Time);
    }
}