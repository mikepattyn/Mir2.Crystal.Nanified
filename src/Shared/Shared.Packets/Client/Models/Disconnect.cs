namespace Shared.Packets.Client.Models;

public sealed class Disconnect : ClientPacket
{
    public override short Index
    {
        get { return (short)ClientPacketIds.Disconnect; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}