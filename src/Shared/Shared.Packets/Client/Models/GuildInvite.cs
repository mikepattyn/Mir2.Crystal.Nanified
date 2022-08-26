namespace Shared.Packets.Client.Models;

public sealed class GuildInvite : Packet
{
    public override short Index { get { return (short)ClientPacketIds.GuildInvite; } }

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