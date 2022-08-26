namespace Shared.Packets.Server.Models;

public sealed class PlaySound : ServerPacket
{
    public int Sound;

    public override short Index
    {
        get { return (short)ServerPacketIds.PlaySound; }
    }

    public override void ReadPacket(BinaryReader reader)
    {
        Sound = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Sound);
    }
}