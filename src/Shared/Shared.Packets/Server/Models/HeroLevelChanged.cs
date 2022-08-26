namespace Shared.Packets.Server.Models;

public sealed class HeroLevelChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.HeroLevelChanged; }
    }

    public ushort Level;
    public long Experience, MaxExperience;

    public override void ReadPacket(BinaryReader reader)
    {
        Level = reader.ReadUInt16();
        Experience = reader.ReadInt64();
        MaxExperience = reader.ReadInt64();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Level);
        writer.Write(Experience);
        writer.Write(MaxExperience);
    }
}