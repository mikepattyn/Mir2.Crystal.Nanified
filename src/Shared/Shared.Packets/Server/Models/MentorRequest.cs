namespace Shared.Packets.Server.Models;

public sealed class MentorRequest : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MentorRequest; } }

    public string Name;
    public ushort Level;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Level = reader.ReadUInt16();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Level);
    }
}