using Shared.Models.Guild;

namespace Shared.Packets.Server.Models;

public sealed class GuildMemberChange : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GuildMemberChange; }
    }
    public string Name = string.Empty;
    public byte Status = 0;
    public byte RankIndex = 0;
    public List<GuildRank> Ranks = new List<GuildRank>();
    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        RankIndex = reader.ReadByte();
        Status = reader.ReadByte();
        if (Status > 5)
        {
            int rankcount = reader.ReadInt32();
            for (int i = 0; i < rankcount; i++)
                Ranks.Add(new GuildRank(reader));
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(RankIndex);
        writer.Write(Status);
        if (Status > 5)
        {
            writer.Write(Ranks.Count);
            for (int i = 0; i < Ranks.Count; i++)
                Ranks[i].Save(writer);
        }
    }
}