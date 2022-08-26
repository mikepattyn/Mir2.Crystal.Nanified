namespace Shared.Packets.Server.Models;

public sealed class UserName : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.UserName; } }
    public uint Id;
    public string Name;
    public override void ReadPacket(BinaryReader reader)
    {
        Id = reader.ReadUInt32();
        Name = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Id);
        writer.Write(Name);
    }
}