namespace Shared.Packets.Server.Models;

public sealed class StartGameDelay : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.StartGameDelay; }
    }

    public long Milliseconds;

    public override void ReadPacket(BinaryReader reader)
    {
        Milliseconds = reader.ReadInt64();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Milliseconds);
    }

}