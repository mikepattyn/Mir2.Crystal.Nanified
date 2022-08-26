using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class AddBuff : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.AddBuff; } }

    public ClientBuff Buff;

    public override void ReadPacket(BinaryReader reader)
    {
        Buff = new ClientBuff(reader);
    }
    public override void WritePacket(BinaryWriter writer)
    {
        Buff.Save(writer);
    }
}