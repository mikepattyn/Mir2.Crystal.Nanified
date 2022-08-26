namespace Shared.Packets.Server.Models;

public sealed class SearchMapResult : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.SearchMapResult; }
    }

    public int MapIndex = -1;
    public uint NPCIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        MapIndex = reader.ReadInt32();
        NPCIndex = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MapIndex);
        writer.Write(NPCIndex);
    }
}