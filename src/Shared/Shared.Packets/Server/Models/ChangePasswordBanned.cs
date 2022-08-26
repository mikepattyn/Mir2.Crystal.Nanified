namespace Shared.Packets.Server.Models;

public sealed class ChangePasswordBanned : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ChangePasswordBanned; }
    }

    public string Reason = string.Empty;
    public DateTime ExpiryDate;

    public override void ReadPacket(BinaryReader reader)
    {
        Reason = reader.ReadString();
        ExpiryDate = DateTime.FromBinary(reader.ReadInt64());
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Reason);
        writer.Write(ExpiryDate.ToBinary());
    }
}