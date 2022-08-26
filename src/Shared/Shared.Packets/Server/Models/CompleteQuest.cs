namespace Shared.Packets.Server.Models;

public sealed class CompleteQuest : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.CompleteQuest; }
    }

    public List<int> CompletedQuests = new List<int>();

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();
        for (var i = 0; i < count; i++)
            CompletedQuests.Add(reader.ReadInt32());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(CompletedQuests.Count);
        foreach (int q in CompletedQuests)
            writer.Write(q);
    }
}