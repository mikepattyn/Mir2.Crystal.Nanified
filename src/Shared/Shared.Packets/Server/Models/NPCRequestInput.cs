namespace Shared.Packets.Server.Models;

public sealed class NPCRequestInput : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCRequestInput; } }

    public uint NPCID;
    public string PageName;

    public override void ReadPacket(BinaryReader reader)
    {
        NPCID = reader.ReadUInt32();
        PageName = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(NPCID);
        writer.Write(PageName);
    }
}