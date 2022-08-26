namespace Shared.Packets.Client.Models;

public sealed class FishingChangeAutocast : Packet
{
    public override short Index { get { return (short)ClientPacketIds.FishingChangeAutocast; } }

    public bool AutoCast;

    public override void ReadPacket(BinaryReader reader)
    {
        AutoCast = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AutoCast);
    }
}