namespace Shared.Packets.Server.Models;

public sealed class AllowObserve : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.AllowObserve; }
    }

    public bool Allow;

    public override void ReadPacket(BinaryReader reader)
    {
        Allow = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Allow);
    }
}