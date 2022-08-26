namespace Shared.Packets.Server.Models;

public sealed class SetBindingShot : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetBindingShot; } }

    public uint ObjectID;
    public bool Enabled;
    public long Value;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Enabled = reader.ReadBoolean();
        Value = reader.ReadInt64();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Enabled);
        writer.Write(Value);
    }
}