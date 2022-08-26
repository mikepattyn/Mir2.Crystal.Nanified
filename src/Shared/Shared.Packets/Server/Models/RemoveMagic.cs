namespace Shared.Packets.Server.Models;

public sealed class RemoveMagic : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.RemoveMagic; }
    }

    public int PlaceId;
    public override void ReadPacket(BinaryReader reader)
    {
        PlaceId = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(PlaceId);
    }

}