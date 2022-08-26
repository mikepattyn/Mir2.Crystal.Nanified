namespace Shared.Packets.Server.Models;

public sealed class Login : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.Login; }
    }

    public byte Result;
    /*
     * 0: Disabled
     * 1: Bad AccountID
     * 2: Bad Password
     * 3: Account Not Exist
     * 4: Wrong Password
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