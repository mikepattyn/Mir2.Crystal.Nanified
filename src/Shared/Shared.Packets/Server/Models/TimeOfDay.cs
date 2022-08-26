using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class TimeOfDay : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.TimeOfDay; }
    }

    public LightSetting Lights;

    public override void ReadPacket(BinaryReader reader)
    {
        Lights = (LightSetting)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Lights);
    }
}