using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ObjectChat : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectChat; }
    }

    public uint ObjectID;
    public string Text = string.Empty;
    public ChatType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Text = reader.ReadString();
        Type = (ChatType)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Text);
        writer.Write((byte)Type);
    }
}