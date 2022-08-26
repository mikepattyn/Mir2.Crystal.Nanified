namespace Shared.Packets.Server.Models;

public sealed class SetConcentration : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetConcentration; } }

    public uint ObjectID;
    public bool Enabled;
    public bool Interrupted;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Enabled = reader.ReadBoolean();
        Interrupted = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Enabled);
        writer.Write(Interrupted);
    }
}