namespace Shared.Packets.Server.Models;

public sealed class SwitchGroup : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SwitchGroup; } }

    public bool AllowGroup;
    public override void ReadPacket(BinaryReader reader)
    {
        AllowGroup = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AllowGroup);
    }
}