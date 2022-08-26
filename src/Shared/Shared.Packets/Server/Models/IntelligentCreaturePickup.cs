namespace Shared.Packets.Server.Models;

public sealed class IntelligentCreaturePickup : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.IntelligentCreaturePickup; }
    }

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