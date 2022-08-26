namespace Shared.Packets.Server.Models;

public sealed class RepairItem : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.RepairItem; } }

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