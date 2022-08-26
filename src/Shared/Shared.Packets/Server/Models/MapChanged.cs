using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class MapChanged : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.MapChanged; }
    }

    public int MapIndex;
    public string FileName = string.Empty;
    public string Title = string.Empty;
    public ushort MiniMap, BigMap, Music;
    public LightSetting Lights;
    public Point Location;
    public MirDirection Direction;
    public byte MapDarkLight;


    public override void ReadPacket(BinaryReader reader)
    {
        MapIndex = reader.ReadInt32();
        FileName = reader.ReadString();
        Title = reader.ReadString();
        MiniMap = reader.ReadUInt16();
        BigMap = reader.ReadUInt16();
        Lights = (LightSetting)reader.ReadByte();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
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
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
        writer.Write(MapDarkLight);
        writer.Write(Music);
    }
}