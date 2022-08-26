namespace Shared.Packets.Server.Models;

public sealed class NPCCheckRefine : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCCheckRefine; } }


    public override void ReadPacket(BinaryReader reader)
    {
    }
    public override void WritePacket(BinaryWriter writer)
    {
    }
}