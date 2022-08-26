namespace Shared.Packets.Client.Models;

public sealed class Inspect : Packet
{
    public override short Index
    {
        get { return (short)ClientPacketIds.Inspect; }
    }

    public uint ObjectID;
    public bool Ranking = false;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Ranking = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Ranking);
    }
}