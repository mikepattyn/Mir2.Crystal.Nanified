namespace Shared.Packets.Client.Models;

public sealed class TakeBackHeroItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.TakeBackHeroItem; } }

    public int From, To;
    public override void ReadPacket(BinaryReader reader)
    {
        From = reader.ReadInt32();
        To = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(From);
        writer.Write(To);
    }
}