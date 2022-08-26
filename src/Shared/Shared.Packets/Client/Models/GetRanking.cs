namespace Shared.Packets.Client.Models;

public sealed class GetRanking : Packet
{
    public override short Index { get { return (short)ClientPacketIds.GetRanking; } }
    public byte RankType;
    public int RankIndex;
    public bool OnlineOnly;

    public override void ReadPacket(BinaryReader reader)
    {
        RankType = reader.ReadByte();
        RankIndex = reader.ReadInt32();
        OnlineOnly = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(RankType);
        writer.Write(RankIndex);
        writer.Write(OnlineOnly);
    }
}