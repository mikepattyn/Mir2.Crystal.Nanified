namespace Shared.Packets.Client.Models;

public sealed class SwitchGroup : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SwitchGroup; } }

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