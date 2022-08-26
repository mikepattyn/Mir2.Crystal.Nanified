namespace Shared.Packets.Server.Models;

public sealed class NPCUpdate : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCUpdate; } }

    public uint NPCID;

    public override void ReadPacket(BinaryReader reader)
    {
        NPCID = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(NPCID);
    }
}