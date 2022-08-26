namespace Shared.Packets.Client.Models;

public sealed class Observe : Packet
{
    public override short Index
    {
        get { return (short)ClientPacketIds.Observe; }
    }

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