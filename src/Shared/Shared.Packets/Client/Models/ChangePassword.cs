namespace Shared.Packets.Client.Models;

public sealed class ChangePassword : Packet
{
    public override short Index
    {
        get { return (short)ClientPacketIds.ChangePassword; }
    }

    public string AccountID = string.Empty;
    public string CurrentPassword = string.Empty;
    public string NewPassword = string.Empty;

    public override void ReadPacket(BinaryReader reader)
    {
        AccountID = reader.ReadString();
        CurrentPassword = reader.ReadString();
        NewPassword = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AccountID);
        writer.Write(CurrentPassword);
        writer.Write(NewPassword);
    }
}