namespace Shared.Packets.Server.Models;

public sealed class RequestReincarnation : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.RequestReincarnation; } }


    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }

}