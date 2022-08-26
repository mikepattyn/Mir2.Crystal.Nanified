namespace Shared.Packets.Server.Models;

public sealed class Opendoor : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.Opendoor; } }

    public bool Close = false;
    public byte DoorIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        DoorIndex = reader.ReadByte();
        Close = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(DoorIndex);
        writer.Write(Close);
    }
}