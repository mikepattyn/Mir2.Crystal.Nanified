using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class SendOutputMessage : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SendOutputMessage; } }

    public string Message;
    public OutputMessageType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        Message = reader.ReadString();
        Type = (OutputMessageType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Message);
        writer.Write((byte)Type);
    }
}