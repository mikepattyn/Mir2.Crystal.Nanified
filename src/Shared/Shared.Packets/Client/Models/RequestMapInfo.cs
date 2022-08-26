namespace Shared.Packets.Client.Models;

public sealed class RequestMapInfo : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RequestMapInfo; } }

    public int MapIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        MapIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MapIndex);
    }
}