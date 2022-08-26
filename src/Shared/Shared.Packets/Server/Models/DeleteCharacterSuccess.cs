namespace Shared.Packets.Server.Models;

public sealed class DeleteCharacterSuccess : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.DeleteCharacterSuccess; }
    }

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