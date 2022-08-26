namespace Shared.Packets.Server.Models;

public sealed class ExpireTimer : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ExpireTimer; } }

    public string Key;

    public override void ReadPacket(BinaryReader reader)
    {
        Key = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Key);
    }
}