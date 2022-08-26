namespace Shared.Packets.Server.Models;

public sealed class BaseStatsInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.BaseStatsInfo; }
    }

    public BaseStats Stats;

    public override void ReadPacket(BinaryReader reader)
    {
        Stats = new BaseStats(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Stats.Save(writer);
    }
}