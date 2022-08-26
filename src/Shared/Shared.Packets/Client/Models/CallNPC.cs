namespace Shared.Packets.Client.Models;

public sealed class CallNPC : Packet
{
    public override short Index { get { return (short)ClientPacketIds.CallNPC; } }

    public uint ObjectID;
    public string Key = string.Empty;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Key = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Key);
    }
}