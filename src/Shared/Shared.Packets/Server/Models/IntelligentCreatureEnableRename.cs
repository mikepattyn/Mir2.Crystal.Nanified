namespace Shared.Packets.Server.Models;

public sealed class IntelligentCreatureEnableRename : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.IntelligentCreatureEnableRename; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
    }

    public override void WritePacket(BinaryWriter writer)
    {
    }
}