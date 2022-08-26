namespace Shared.Packets.Client.Models;

public sealed class EditGuildMember : Packet
{
    public override short Index { get { return (short)ClientPacketIds.EditGuildMember; } }

    public byte ChangeType = 0;
    public byte RankIndex = 0;
    public string Name = "";
    public string RankName = "";

    public override void ReadPacket(BinaryReader reader)
    {
        ChangeType = reader.ReadByte();
        RankIndex = reader.ReadByte();
        Name = reader.ReadString();
        RankName = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ChangeType);
        writer.Write(RankIndex);
        writer.Write(Name);
        writer.Write(RankName);
    }
}