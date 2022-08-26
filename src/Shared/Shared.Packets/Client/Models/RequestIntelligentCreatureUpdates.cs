namespace Shared.Packets.Client.Models;

public sealed class RequestIntelligentCreatureUpdates : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RequestIntelligentCreatureUpdates; } }

    public bool Update = false;

    public override void ReadPacket(BinaryReader reader)
    {
        Update = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Update);
    }
}