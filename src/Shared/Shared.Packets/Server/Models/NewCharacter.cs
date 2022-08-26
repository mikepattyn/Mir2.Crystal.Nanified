namespace Shared.Packets.Server.Models;

public sealed class NewCharacter : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewCharacter; }
    }

    /*
     * 0: Disabled.
     * 1: Bad Character Name
     * 2: Bad Gender
     * 3: Bad Class
     * 4: Max Characters
     * 5: Character Exists.
     * 
     * 10: Success
     * */
    public byte Result;

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }
}