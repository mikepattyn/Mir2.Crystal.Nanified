namespace Shared.Packets.Client.Models;

public sealed class ReplaceWedRing : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ReplaceWedRing; } }

    public ulong UniqueID;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
    }
}