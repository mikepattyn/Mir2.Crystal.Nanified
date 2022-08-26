namespace Shared.Packets.Client.Models;

public sealed class CheckRefine : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CheckRefine; } }

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