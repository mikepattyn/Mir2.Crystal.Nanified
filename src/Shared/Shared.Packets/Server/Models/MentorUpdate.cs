namespace Shared.Packets.Server.Models;

public sealed class MentorUpdate : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MentorUpdate; }
    }

    public string Name;
    public ushort Level;
    public bool Online;
    public long MenteeEXP;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Level = reader.ReadUInt16();
        Online = reader.ReadBoolean();
        MenteeEXP = reader.ReadInt64();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Level);
        writer.Write(Online);
        writer.Write(MenteeEXP);
    }
}