namespace Shared.Packets.Client.Models;

public sealed class DropGold : Packet
{
    public override short Index { get { return (short)ClientPacketIds.DropGold; } }

    public uint Amount;

    public override void ReadPacket(BinaryReader reader)
    {
        Amount = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Amount);
    }
}