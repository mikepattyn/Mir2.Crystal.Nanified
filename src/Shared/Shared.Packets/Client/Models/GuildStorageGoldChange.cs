namespace Shared.Packets.Client.Models;

public sealed class GuildStorageGoldChange : Packet
{
    public override short Index { get { return (short)ClientPacketIds.GuildStorageGoldChange; } }

    public byte Type = 0;
    public uint Amount = 0;

    public override void ReadPacket(BinaryReader reader)
    {
        Type = reader.ReadByte();
        Amount = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Type);
        writer.Write(Amount);
    }
}