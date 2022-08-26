namespace Shared.Packets.Server.Models;

public sealed class LoverUpdate : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.LoverUpdate; }
    }

    public string Name;
    public DateTime Date;
    public string MapName;
    public short MarriedDays;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Date = DateTime.FromBinary(reader.ReadInt64());
        MapName = reader.ReadString();
        MarriedDays = reader.ReadInt16();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Date.ToBinary());
        writer.Write(MapName);
        writer.Write(MarriedDays);
    }
}