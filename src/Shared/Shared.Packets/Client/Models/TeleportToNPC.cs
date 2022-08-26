namespace Shared.Packets.Client.Models;

public sealed class TeleportToNPC : Packet
{
    public override short Index { get { return (short)ClientPacketIds.TeleportToNPC; } }

    public uint ObjectID;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
    }
}