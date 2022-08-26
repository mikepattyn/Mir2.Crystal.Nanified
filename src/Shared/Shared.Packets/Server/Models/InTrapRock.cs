namespace Shared.Packets.Server.Models;

public sealed class InTrapRock : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.InTrapRock; } }
    public bool Trapped;

    public override void ReadPacket(BinaryReader reader)
    {
        Trapped = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Trapped);
    }
}