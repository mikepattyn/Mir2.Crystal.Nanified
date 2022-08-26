namespace Shared.Packets.Server.Models;

public sealed class NewAccount : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewAccount; }
    }

    public byte Result;
    /*
     * 0: Disabled
     * 1: Bad AccountID
     * 2: Bad Password
     * 3: Bad Email
     * 4: Bad Name
     * 5: Bad Question
     * 6: Bad Answer
     * 7: Account Exists.
     * 8: Success
     */

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }

}