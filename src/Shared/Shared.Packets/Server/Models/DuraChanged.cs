namespace Shared.Packets.Server.Models;

public sealed class DuraChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.DuraChanged; }
    }

    public ulong UniqueID;
    public ushort CurrentDura;

    public override void ReadPacket(BinaryReader reader)
    {
        UniqueID = reader.ReadUInt64();
        CurrentDura = reader.ReadUInt16();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UniqueID);
        writer.Write(CurrentDura);
    }
}