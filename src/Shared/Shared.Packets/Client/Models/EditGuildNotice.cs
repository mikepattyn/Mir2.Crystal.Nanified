namespace Shared.Packets.Client.Models;

public sealed class EditGuildNotice : Packet
{
    public override short Index { get { return (short)ClientPacketIds.EditGuildNotice; } }

    public List<string> notice = new List<string>();

    public override void ReadPacket(BinaryReader reader)
    {
        int LineCount = reader.ReadInt32();
        for (int i = 0; i < LineCount; i++)
            notice.Add(reader.ReadString());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(notice.Count);
        for (int i = 0; i < notice.Count; i++)
            writer.Write(notice[i]);
    }
}