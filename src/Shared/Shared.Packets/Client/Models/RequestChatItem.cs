namespace Shared.Packets.Client.Models;

public sealed class RequestChatItem : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RequestChatItem; } }

    public ulong ChatItemID;

    public override void ReadPacket(BinaryReader reader)
    {
        ChatItemID = reader.ReadUInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ChatItemID);
    }
}