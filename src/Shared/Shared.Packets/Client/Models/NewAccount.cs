namespace Shared.Packets.Client.Models;

public sealed class NewAccount : Packet
{
    public override short Index
    {
        get { return (short)ClientPacketIds.NewAccount; }
    }

    public string AccountID = string.Empty;
    public string Password = string.Empty;
    public DateTime BirthDate;
    public string UserName = string.Empty;
    public string SecretQuestion = string.Empty;
    public string SecretAnswer = string.Empty;
    public string EMailAddress = string.Empty;

    public override void ReadPacket(BinaryReader reader)
    {
        AccountID = reader.ReadString();
        Password = reader.ReadString();
        BirthDate = DateTime.FromBinary(reader.ReadInt64());
        UserName = reader.ReadString();
        SecretQuestion = reader.ReadString();
        SecretAnswer = reader.ReadString();
        EMailAddress = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(AccountID);
        writer.Write(Password);
        writer.Write(BirthDate.ToBinary());
        writer.Write(UserName);
        writer.Write(SecretQuestion);
        writer.Write(SecretAnswer);
        writer.Write(EMailAddress);
    }
}