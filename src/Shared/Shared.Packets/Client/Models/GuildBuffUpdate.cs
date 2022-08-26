namespace Shared.Packets.Client.Models;

public sealed class GuildBuffUpdate : Packet
{
    public override short Index { get { return (short)ClientPacketIds.GuildBuffUpdate; } }

    public byte Action = 0; //0 = request list, 1 = request a buff to be enabled, 2 = request a buff to be activated
    public int Id;

    public override void ReadPacket(BinaryReader reader)
    {
        Action = reader.ReadByte();
        Id = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Action);
        writer.Write(Id);
    }
}