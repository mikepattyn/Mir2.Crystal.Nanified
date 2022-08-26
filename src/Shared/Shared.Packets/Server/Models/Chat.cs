using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class Chat : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.Chat; }
    }

    public override bool Observable
    {
        get { return Type != ChatType.WhisperIn && Type != ChatType.WhisperOut; }
    }

    public string Message = string.Empty;
    public ChatType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        Message = reader.ReadString();
        Type = (ChatType)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Message);
        writer.Write((byte)Type);
    }
}