namespace Shared.Packets.Server.Models;

public sealed class ConsignItem : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ConsignItem; } }

    public ulong UniqueID;
    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        Success = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(Success);
    }
}