namespace Shared.Packets.Client.Models;

public sealed class DowngradeAwakening : Packet
{
    public override short Index { get { return (short)ClientPacketIds.DowngradeAwakening; } }

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