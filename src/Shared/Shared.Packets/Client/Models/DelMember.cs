namespace Shared.Packets.Client.Models;

public sealed class DelMember : Packet
{
    public override short Index { get { return (short)ClientPacketIds.DellMember; } }

    public string Name = string.Empty;
    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
    }
}