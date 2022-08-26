namespace Shared.Packets.Server.Models;

public sealed class GuildExpGain : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.GuildExpGain; } }

    public uint Amount = 0;
    public override void ReadPacket(BinaryReader reader)
    {
        Amount = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Amount);
    }
}