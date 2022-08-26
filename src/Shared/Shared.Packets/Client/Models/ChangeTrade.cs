namespace Shared.Packets.Client.Models;

public sealed class ChangeTrade : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ChangeTrade; } }

    public bool AllowTrade;

    public override void ReadPacket(BinaryReader reader)
    {
        AllowTrade = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AllowTrade);
    }
}