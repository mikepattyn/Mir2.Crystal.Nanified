namespace Shared.Packets.Server.Models;

public sealed class DeleteMember : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.DeleteMember; } }

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