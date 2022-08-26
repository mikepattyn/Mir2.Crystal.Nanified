namespace Shared.Packets.Client.Models;

public sealed class MailCost : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MailCost; } }

    public uint Gold;
    public ulong[] ItemsIdx = new ulong[5];
    public bool Stamped;

    public override void ReadPacket(BinaryReader reader)
    {
        Gold = reader.ReadUInt32();

        for (int i = 0; i < 5; i++)
        {
            ItemsIdx[i] = reader.ReadUInt64();
        }

        Stamped = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Gold);

        for (int i = 0; i < 5; i++)
        {
            writer.Write(ItemsIdx[i]);
        }

        writer.Write(Stamped);
    }
}