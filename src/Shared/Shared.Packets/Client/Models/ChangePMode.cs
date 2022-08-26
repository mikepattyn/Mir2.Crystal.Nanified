using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class ChangePMode : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ChangePMode; } }

    public PetMode Mode;

    public override void ReadPacket(BinaryReader reader)
    {
        Mode = (PetMode)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Mode);
    }
}