using Shared.Enums;

namespace Shared.Models.Guild;

public class GuildRank
{
    public List<GuildMember> Members = new List<GuildMember>();
    public string Name = "";
    public int Index = 0;
    public GuildRankOptions Options = (GuildRankOptions)0;

    public GuildRank() { }

    public GuildRank(BinaryReader reader, bool offline = false)
    {
        Name = reader.ReadString();
        Options = (GuildRankOptions)reader.ReadByte();

        if (!offline)
        {
            Index = reader.ReadInt32();
        }

        int Membercount = reader.ReadInt32();
        for (int j = 0; j < Membercount; j++)
        {
            Members.Add(new GuildMember(reader, offline));
        }
    }
    public void Save(BinaryWriter writer, bool save = false)
    {
        writer.Write(Name);
        writer.Write((byte)Options);
        if (!save)
        {
            writer.Write(Index);
        }

        writer.Write(Members.Count);

        for (int j = 0; j < Members.Count; j++)
        {
            Members[j].Save(writer);
        }
    }
}

//outdated but cant delete it or old db's wont load