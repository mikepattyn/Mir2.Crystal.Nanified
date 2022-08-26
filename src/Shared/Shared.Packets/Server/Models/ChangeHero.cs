namespace Shared.Packets.Server.Models;

public sealed class ChangeHero : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ChangeHero; } }

    public int FromIndex;
    public override void ReadPacket(BinaryReader reader)
    {
        FromIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(FromIndex);
    }
}