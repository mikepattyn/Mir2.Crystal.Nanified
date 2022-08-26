using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NewMapInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewMapInfo; }
    }

    public int MapIndex;
    public ClientMapInfo Info;

    public override void ReadPacket(BinaryReader reader)
    {
        MapIndex = reader.ReadInt32();
        Info = new ClientMapInfo(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MapIndex);
        Info.Save(writer);
    }
}