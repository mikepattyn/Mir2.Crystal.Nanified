namespace Shared.Packets.Client.Models;

public sealed class TradeReply : Packet
{
    public override short Index { get { return (short)ClientPacketIds.TradeReply; } }

    public bool AcceptInvite;
    public override void ReadPacket(BinaryReader reader)
    {
        AcceptInvite = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AcceptInvite);
    }
}