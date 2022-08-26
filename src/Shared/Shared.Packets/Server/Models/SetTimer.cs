namespace Shared.Packets.Server.Models;

public sealed class SetTimer : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetTimer; } }

    public string Key;
    public byte Type;
    public int Seconds;

    public override void ReadPacket(BinaryReader reader)
    {
        Key = reader.ReadString();
        Type = reader.ReadByte();
        Seconds = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Key);
        writer.Write(Type);
        writer.Write(Seconds);
    }
}