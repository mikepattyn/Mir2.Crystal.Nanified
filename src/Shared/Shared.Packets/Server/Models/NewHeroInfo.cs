using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NewHeroInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewHeroInfo; }
    }

    public ClientHeroInformation Info;
    public int StorageIndex = -1;

    public override void ReadPacket(BinaryReader reader)
    {
        Info = new ClientHeroInformation(reader);
        StorageIndex = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Info.Save(writer);
        writer.Write(StorageIndex);
    }
}