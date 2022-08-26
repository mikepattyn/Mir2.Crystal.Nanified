namespace Shared.Packets.Server.Models;

public sealed class TradeCancel : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.TradeCancel; }
    }

    public bool Unlock;
    public override void ReadPacket(BinaryReader reader)
    {
        Unlock = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Unlock);
    }
}