namespace Shared.Packets.Client.Models;

public sealed class AcceptQuest : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AcceptQuest; } }

    public uint NPCIndex;
    public int QuestIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        NPCIndex = reader.ReadUInt32();
        QuestIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(NPCIndex);
        writer.Write(QuestIndex);
    }
}