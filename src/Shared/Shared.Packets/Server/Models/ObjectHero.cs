namespace Shared.Packets.Server.Models;

public sealed class ObjectHero : ObjectPlayer
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectHero; }
    }

    public string OwnerName;

    public override void ReadPacket(BinaryReader reader)
    {
        base.ReadPacket(reader);

        OwnerName = reader.ReadString();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        base.WritePacket(writer);

        writer.Write(OwnerName);
    }
}