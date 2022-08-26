namespace Shared.Packets.Client.Models;

public sealed class RequestUserName : Packet
{
    public override short Index { get { return (short)ClientPacketIds.RequestUserName; } }

    public uint UserID;

    public override void ReadPacket(BinaryReader reader)
    {
        UserID = reader.ReadUInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(UserID);
    }
}