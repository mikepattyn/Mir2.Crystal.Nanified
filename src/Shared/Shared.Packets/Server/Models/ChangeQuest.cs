using Shared.Enums;
using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class ChangeQuest : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ChangeQuest; }
    }

    public ClientQuestProgress Quest = new ClientQuestProgress();
    public QuestState QuestState;
    public bool TrackQuest;

    public override void ReadPacket(BinaryReader reader)
    {
        Quest = new ClientQuestProgress(reader);
        QuestState = (QuestState)reader.ReadByte();
        TrackQuest = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        Quest.Save(writer);
        writer.Write((byte)QuestState);
        writer.Write(TrackQuest);
    }
}