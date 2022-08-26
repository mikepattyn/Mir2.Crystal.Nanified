namespace Shared.Packets.Server.Models;

public sealed class ShareQuest : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ShareQuest; }
    }

    public int QuestIndex;
    public string SharerName;

    public override void ReadPacket(BinaryReader reader)
    {
        QuestIndex = reader.ReadInt32();
        SharerName = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(QuestIndex);
        writer.Write(SharerName);
    }
}