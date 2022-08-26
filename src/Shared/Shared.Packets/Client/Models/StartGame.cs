namespace Shared.Packets.Client.Models;

public sealed class StartGame : Packet
{
    public override short Index { get { return (short)ClientPacketIds.StartGame; } }

    public int CharacterIndex;

    public override void ReadPacket(BinaryReader reader)
    {
        CharacterIndex = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(CharacterIndex);
    }
}