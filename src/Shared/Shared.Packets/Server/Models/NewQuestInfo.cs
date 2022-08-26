using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NewQuestInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewQuestInfo; }
    }

    public ClientQuestInfo Info;

    public override void ReadPacket(BinaryReader reader)
    {
        Info = new ClientQuestInfo(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Info.Save(writer);
    }
}