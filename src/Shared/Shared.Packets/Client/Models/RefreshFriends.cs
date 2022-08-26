namespace Shared.Packets.Client.Models;

public sealed class RefreshFriends : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RefreshFriends; } }

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}