namespace Shared.Packets.Client.Models;

public sealed class Login : Packet
{
    public override short Index
    {
        get { return (short)ClientPacketIds.Login; }
    }

    public string AccountID = string.Empty;
    public string Password = string.Empty;

    public override void ReadPacket(BinaryReader reader)
    {
        AccountID = reader.ReadString();
        Password = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AccountID);
        writer.Write(Password);
    }
}