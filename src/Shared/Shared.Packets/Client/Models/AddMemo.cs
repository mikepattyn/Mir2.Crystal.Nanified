namespace Shared.Packets.Client.Models;

public sealed class AddMemo : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AddMemo; } }

    public int CharacterIndex;
    public string Memo;

    public override void ReadPacket(BinaryReader reader)
    {
        CharacterIndex = reader.ReadInt32();
        Memo = reader.ReadString();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(CharacterIndex);
        writer.Write(Memo);
    }
}