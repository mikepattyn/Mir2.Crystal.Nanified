namespace Shared.Packets.Client.Models;

public sealed class ChangeHero : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ChangeHero; } }

    public int ListIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        ListIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ListIndex);
    }
}