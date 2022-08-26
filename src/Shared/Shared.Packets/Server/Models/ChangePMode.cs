using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class ChangePMode : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ChangePMode; }
    }

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