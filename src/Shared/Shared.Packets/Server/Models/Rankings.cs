using Shared.Models.Shared;

namespace Shared.Packets.Server.Models;

public sealed class Rankings : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.Rankings; } }
    public override bool Observable
    {
        get { return false; }
    }

    public byte RankType = 0;
    public int MyRank = 0;
    public List<RankCharacterInfo> ListingDetails = new List<RankCharacterInfo>();
    public List<long> Listings = new List<long>();
    public int Count;

    public override void ReadPacket(BinaryReader reader)
    {
        RankType = reader.ReadByte();
        MyRank = reader.ReadInt32();
        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            ListingDetails.Add(new RankCharacterInfo(reader));
        }
        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            Listings.Add(reader.ReadInt64());
        }
        Count = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(RankType);
        writer.Write(MyRank);
        writer.Write(ListingDetails.Count);
        for (int i = 0; i < ListingDetails.Count; i++)
            ListingDetails[i].Save(writer);
        writer.Write(Listings.Count);
        for (int i = 0; i < Listings.Count; i++)
            writer.Write(Listings[i]);
        writer.Write(Count);
    }
}