namespace Shared.Packets.Server.Models;

public sealed class MailCost : ServerPacket
{
    public uint Cost;

    public override short Index
    {
        get { return (short)ServerPacketIds.MailCost; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        Cost = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Cost);
    }
}