namespace Shared.Packets.Server.Models;

public sealed class HealthChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.HealthChanged; }
    }

    public int HP, MP;

    public override void ReadPacket(BinaryReader reader)
    {
        HP = reader.ReadInt32();
        MP = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(HP);
        writer.Write(MP);
    }
}