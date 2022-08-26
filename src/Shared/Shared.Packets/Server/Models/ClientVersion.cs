namespace Shared.Packets.Server.Models;

public sealed class ClientVersion : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ClientVersion; }
    }

    public byte Result;
    /*
     * 0: Wrong Version
     * 1: Correct Version
     */

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }
}

//public sealed class UpdateQuests : ServerPacket
//{
//    public override short Index
//    {
//        get { return (short)ServerPacketIds.UpdateQuests; }
//    }

//    public List<ClientQuestProgress> CurrentQuests = new List<ClientQuestProgress>();
//    public List<int> CompletedQuests = new List<int>();

//    public override void ReadPacket(BinaryReader reader)
//    {
//        int count = reader.ReadInt32();
//        for (var i = 0; i < count; i++)
//            CurrentQuests.Add(new ClientQuestProgress(reader));

//        count = reader.ReadInt32();
//        for (var i = 0; i < count; i++)
//            CompletedQuests.Add(reader.ReadInt32());
//    }
//    public override void WritePacket(BinaryWriter writer)
//    {
//        writer.Write(CurrentQuests.Count);
//        foreach (var q in CurrentQuests)
//            q.Save(writer);

//        writer.Write(CompletedQuests.Count);
//        foreach (int q in CompletedQuests)
//            writer.Write(q);
//    }
//}