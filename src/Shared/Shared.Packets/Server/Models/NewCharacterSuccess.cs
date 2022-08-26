using Shared.Models.Shared;

namespace Shared.Packets.Server.Models;

public sealed class NewCharacterSuccess : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewCharacterSuccess; }
    }

    public SelectInfo CharInfo;

    public override void ReadPacket(BinaryReader reader)
    {
        CharInfo = new SelectInfo(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        CharInfo.Save(writer);
    }
}