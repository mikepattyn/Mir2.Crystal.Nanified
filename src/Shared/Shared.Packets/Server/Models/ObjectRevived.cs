namespace Shared.Packets.Server.Models;

public sealed class ObjectRevived : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectRevived; } }
    public uint ObjectID;
    public bool Effect;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Effect = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Effect);
    }
}