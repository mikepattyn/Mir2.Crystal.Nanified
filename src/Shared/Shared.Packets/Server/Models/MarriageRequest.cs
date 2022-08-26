namespace Shared.Packets.Server.Models;

public sealed class MarriageRequest : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.MarriageRequest; } }

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