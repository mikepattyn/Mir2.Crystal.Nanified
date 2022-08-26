namespace Shared.Packets.Client.Models;

public sealed class Opendoor : Packet
{
    public override short Index { get { return (short)ClientPacketIds.Opendoor; } }
    public byte DoorIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        DoorIndex = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(DoorIndex);
    }
}