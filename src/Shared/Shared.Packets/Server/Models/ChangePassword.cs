namespace Shared.Packets.Server.Models;

public sealed class ChangePassword : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ChangePassword; }
    }

    public byte Result;
    /*
     * 0: Disabled
     * 1: Bad AccountID
     * 2: Bad Current Password
     * 3: Bad New Password
     * 4: Account Not Exist
     * 5: Wrong Password
     * 6: Success
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