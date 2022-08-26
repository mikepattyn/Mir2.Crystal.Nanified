namespace Shared.Packets.Client.Models;

public sealed class ShareQuest : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ShareQuest; } }

    public int QuestIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        QuestIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(QuestIndex);
    }
}