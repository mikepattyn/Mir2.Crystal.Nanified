namespace Shared.Packets.Server.Models;

public sealed class Struck : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.Struck; }
    }

    public uint AttackerID;

    public override void ReadPacket(BinaryReader reader)
    {
        AttackerID = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AttackerID);
    }
}