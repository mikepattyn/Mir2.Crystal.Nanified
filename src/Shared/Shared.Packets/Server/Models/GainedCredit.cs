namespace Shared.Packets.Server.Models;

public sealed class GainedCredit : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GainedCredit; }
    }

    public uint Credit;

    public override void ReadPacket(BinaryReader reader)
    {
        Credit = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Credit);
    }
}