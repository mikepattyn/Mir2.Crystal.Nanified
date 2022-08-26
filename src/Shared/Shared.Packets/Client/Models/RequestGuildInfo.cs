namespace Shared.Packets.Client.Models;

public sealed class RequestGuildInfo : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RequestGuildInfo; } }

    public byte Type;

    public override void ReadPacket(BinaryReader reader)
    {
        Type = reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Type);
    }
}