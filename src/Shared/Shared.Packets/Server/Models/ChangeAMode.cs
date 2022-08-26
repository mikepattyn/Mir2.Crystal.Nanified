using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ChangeAMode : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ChangeAMode; }
    }

    public AttackMode Mode;

    public override void ReadPacket(BinaryReader reader)
    {
        Mode = (AttackMode)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Mode);
    }
}