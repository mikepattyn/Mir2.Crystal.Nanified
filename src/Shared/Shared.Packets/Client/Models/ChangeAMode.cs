using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class ChangeAMode : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ChangeAMode; } }

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