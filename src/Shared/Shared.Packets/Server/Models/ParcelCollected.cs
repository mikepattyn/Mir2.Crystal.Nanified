namespace Shared.Packets.Server.Models;

public sealed class ParcelCollected : ServerPacket
{
    public sbyte Result;

    public override short Index
    {
        get { return (short)ServerPacketIds.ParcelCollected; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadSByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }
}