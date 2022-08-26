using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class ChatItemStats : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ChatItemStats; } }
    public ulong ChatItemId;
    public UserItem Stats;
    public override void ReadPacket(BinaryReader reader)
    {
        ChatItemId = reader.ReadUInt64();
        Stats = new UserItem(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ChatItemId);
        if (Stats != null) Stats.Save(writer);
    }
}