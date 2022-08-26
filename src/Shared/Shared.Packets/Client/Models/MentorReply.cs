namespace Shared.Packets.Client.Models;

public sealed class MentorReply : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MentorReply; } }

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