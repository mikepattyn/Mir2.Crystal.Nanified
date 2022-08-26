namespace Shared.Packets.Server.Models;

public sealed class NPCResponse : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCResponse; } }

    public List<string> Page;

    public override void ReadPacket(BinaryReader reader)
    {
        Page = new List<string>();

        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Page.Add(reader.ReadString());
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Page.Count);

        for (int i = 0; i < Page.Count; i++)
            writer.Write(Page[i]);
    }
}