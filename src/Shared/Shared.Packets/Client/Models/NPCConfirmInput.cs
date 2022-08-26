namespace Shared.Packets.Client.Models;

public sealed class NPCConfirmInput : Packet
{
    public override short Index { get { return (short)ClientPacketIds.NPCConfirmInput; } }

    public uint NPCID;
    public string PageName;
    public string Value;

    public override void ReadPacket(BinaryReader reader)
    {
        NPCID = reader.ReadUInt32();
        PageName = reader.ReadString();
        Value = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(NPCID);
        writer.Write(PageName);
        writer.Write(Value);
    }
}