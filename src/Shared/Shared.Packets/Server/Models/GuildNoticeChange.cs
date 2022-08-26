namespace Shared.Packets.Server.Models;

public sealed class GuildNoticeChange : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GuildNoticeChange; }
    }
    public int update = 0;
    public List<string> notice = new List<string>();
    public override void ReadPacket(BinaryReader reader)
    {
        update = reader.ReadInt32();
        for (int i = 0; i < update; i++)
            notice.Add(reader.ReadString());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        if (update < 0)
        {
            writer.Write(update);
            return;
        }
        writer.Write(notice.Count);
        for (int i = 0; i < notice.Count; i++)
            writer.Write(notice[i]);
    }
}