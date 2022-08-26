namespace Shared.Packets.Client.Models;

public sealed class SendMail : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SendMail; } }

    public string Name;
    public string Message;
    public uint Gold;
    public ulong[] ItemsIdx = new ulong[5];
    public bool Stamped;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Message = reader.ReadString();
        Gold = reader.ReadUInt32();

        for (int i = 0; i < 5; i++)
        {
            ItemsIdx[i] = reader.ReadUInt64();
        }

        Stamped = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Message);
        writer.Write(Gold);

        for (int i = 0; i < 5; i++)
        {
            writer.Write(ItemsIdx[i]);
        }

        writer.Write(Stamped);
    }
}