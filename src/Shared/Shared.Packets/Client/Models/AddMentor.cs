namespace Shared.Packets.Client.Models;

public sealed class AddMentor : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AddMentor; } }

    public string Name;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
    }
}