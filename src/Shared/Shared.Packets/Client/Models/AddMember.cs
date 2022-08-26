namespace Shared.Packets.Client.Models;

public sealed class AddMember : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AddMember; } }

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