namespace Shared.Packets.Client.Models;

public sealed class MarriageReply : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MarriageReply; } }

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