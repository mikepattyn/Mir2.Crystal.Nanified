namespace Shared.Packets.Server.Models;

public sealed class LoseCredit : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.LoseCredit; }
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