namespace Shared.Packets.Client.Models;

public sealed class FishingCast : Packet
{
    public override short Index { get { return (short)ClientPacketIds.FishingCast; } }

    public bool CastOut;

    public override void ReadPacket(BinaryReader reader)
    {
        CastOut = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(CastOut);
    }
}