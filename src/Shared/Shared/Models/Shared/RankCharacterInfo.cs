using Shared.Enums;

namespace Shared.Models.Shared;

public class RankCharacterInfo
{
    public long PlayerId;
    public string Name;
    public MirClass Class;
    public int level;

    public long Experience;//clients shouldnt care about this only server
    public object info;//again only keep this on server!
    public DateTime LastUpdated;

    public RankCharacterInfo()
    {

    }
    public RankCharacterInfo(BinaryReader reader)
    {
        PlayerId = reader.ReadInt64();
        Name = reader.ReadString();
        level = reader.ReadInt32();
        Class = (MirClass)reader.ReadByte();

    }
    public void Save(BinaryWriter writer)
    {
        writer.Write(PlayerId);
        writer.Write(Name);
        writer.Write(level);
        writer.Write((byte)Class);
    }
}