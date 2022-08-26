namespace Shared.Packets.Server.Models;

public sealed class Awakening : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.Awakening; } }

    public int result;
    public long removeID = -1;

    public override void ReadPacket(BinaryReader reader)
    {
        result = reader.ReadInt32();
        removeID = reader.ReadInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(result);
        writer.Write(removeID);
    }
}