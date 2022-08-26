namespace Shared.Packets.Server.Models;

public sealed class ItemRepaired : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ItemRepaired; } }

    public ulong UniqueID;
    public ushort MaxDura, CurrentDura;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        MaxDura = reader.ReadUInt16();
        CurrentDura = reader.ReadUInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(MaxDura);
        writer.Write(CurrentDura);
    }
}