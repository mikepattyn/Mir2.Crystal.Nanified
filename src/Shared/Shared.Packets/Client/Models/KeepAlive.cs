namespace Shared.Packets.Client.Models;

public sealed class KeepAlive : Packet
{
    public override short Index
    {
        get { return (short)ClientPacketIds.KeepAlive; }
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