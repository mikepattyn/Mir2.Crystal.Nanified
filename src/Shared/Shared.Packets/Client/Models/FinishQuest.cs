namespace Shared.Packets.Client.Models;

public sealed class FinishQuest : Packet
{
    public override short Index { get { return (short)ClientPacketIds.FinishQuest; } }

    public int QuestIndex;
    public int SelectedItemIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        QuestIndex = reader.ReadInt32();
        SelectedItemIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(QuestIndex);
        writer.Write(SelectedItemIndex);
    }
}