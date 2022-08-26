namespace Shared.Packets.Server.Models;

public sealed class GuildStorageGoldChange : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.GuildStorageGoldChange; } }
    public uint Amount = 0;
    public byte Type = 0;
    public string Name = string.Empty;

    public override void ReadPacket(BinaryReader reader)
    {
        Amount = reader.ReadUInt32();
        Type = reader.ReadByte();
        Name = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Amount);
        writer.Write(Type);
        writer.Write(Name);
    }
}