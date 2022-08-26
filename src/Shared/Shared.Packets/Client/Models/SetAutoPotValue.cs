using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class SetAutoPotValue : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SetAutoPotValue; } }

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