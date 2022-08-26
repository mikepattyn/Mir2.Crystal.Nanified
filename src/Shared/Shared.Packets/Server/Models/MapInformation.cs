using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class MapInformation : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MapInformation; }
    }

    public int MapIndex;
    public string FileName = string.Empty;
    public string Title = string.Empty;
    public ushort MiniMap, BigMap, Music;
    public LightSetting Lights;
    public bool Lightning, Fire;
    public byte MapDarkLight;

    public override void ReadPacket(BinaryReader reader)
    {
        MapIndex = reader.ReadInt32();
        FileName = reader.ReadString();
        Title = reader.ReadString();
        MiniMap = reader.ReadUInt16();
        BigMap = reader.ReadUInt16();
        Lights = (LightSetting)reader.ReadByte();
        byte bools = reader.ReadByte();
        if ((bools & 0x01) == 0x01) Lightning = true;
        if ((bools & 0x02) == 0x02) Fire = true;
        MapDarkLight = reader.ReadByte();
        Music = reader.ReadUInt16();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MapIndex);
        writer.Write(FileName);
        writer.Write(Title);
        writer.Write(MiniMap);
        writer.Write(BigMap);
        writer.Write((byte)Lights);
        byte bools = 0;
        bools |= (byte)(Lightning ? 0x01 : 0);
        bools |= (byte)(Fire ? 0x02 : 0);
        writer.Write(bools);
        writer.Write(MapDarkLight);
        writer.Write(Music);
    }
}