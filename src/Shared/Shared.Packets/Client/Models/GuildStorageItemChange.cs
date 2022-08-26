namespace Shared.Packets.Client.Models;

public sealed class GuildStorageItemChange : Packet
{
    public override short Index { get { return (short)ClientPacketIds.GuildStorageItemChange; } }

    public byte Type = 0;
    public int From, To;
    public override void ReadPacket(BinaryReader reader)
    {
        Type = reader.ReadByte();
        From = reader.ReadInt32();
        To = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Type);
        writer.Write(From);
        writer.Write(To);
    }
}