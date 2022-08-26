using Shared.Models.Items;

namespace Shared.Packets.Client.Models;

public sealed class Chat : Packet
{
    public override short Index { get { return (short)ClientPacketIds.Chat; } }

    public string Message = string.Empty;
    public List<ChatItem> LinkedItems = new List<ChatItem>();

    public override void ReadPacket(BinaryReader reader)
    {
        Message = reader.ReadString();

        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            LinkedItems.Add(new ChatItem(reader));
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Message);

        writer.Write(LinkedItems.Count);

        for (int i = 0; i < LinkedItems.Count; i++)
            LinkedItems[i].Save(writer);
    }
}