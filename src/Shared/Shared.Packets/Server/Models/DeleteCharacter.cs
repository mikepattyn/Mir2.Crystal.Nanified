namespace Shared.Packets.Server.Models;

public sealed class DeleteCharacter : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.DeleteCharacter; }
    }

    public byte Result;

    /*
     * 0: Disabled.
     * 1: Character Not Found
     * */

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }
}