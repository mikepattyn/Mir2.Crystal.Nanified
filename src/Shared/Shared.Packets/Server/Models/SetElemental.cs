namespace Shared.Packets.Server.Models;

public sealed class SetElemental : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetElemental; } }

    public uint ObjectID;
    public bool Enabled;
    public bool Casted;
    public uint Value;
    public uint ElementType;
    public uint ExpLast;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Enabled = reader.ReadBoolean();
        Casted = reader.ReadBoolean();
        Value = reader.ReadUInt32();
        ElementType = reader.ReadUInt32();
        ExpLast = reader.ReadUInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Enabled);
        writer.Write(Casted);
        writer.Write(Value);
        writer.Write(ElementType);
        writer.Write(ExpLast);
    }
}