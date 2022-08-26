namespace Shared.Packets.Server.Models;

public sealed class NPCCollectRefine : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCCollectRefine; } }

    public bool Success;

    public override void ReadPacket(BinaryReader reader)
    {
        Success = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Success);
    }
}