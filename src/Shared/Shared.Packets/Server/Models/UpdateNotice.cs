using Shared.Models;

namespace Shared.Packets.Server.Models;

public sealed class UpdateNotice : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UpdateNotice; }
    }

    public Notice Notice = new Notice();

    public override void ReadPacket(BinaryReader reader)
    {
        Notice = new Notice(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Notice.Save(writer);
    }
}