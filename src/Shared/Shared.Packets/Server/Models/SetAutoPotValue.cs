using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class SetAutoPotValue : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetAutoPotValue; } }

    public Stat Stat;
    public uint Value;
    public override void ReadPacket(BinaryReader reader)
    {
        Stat = (Stat)reader.ReadByte();
        Value = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Stat);
        writer.Write(Value);
    }
}