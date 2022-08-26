namespace Shared.Packets.Server.Models;

public sealed class ItemRentalRequest : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ItemRentalRequest; } }

    public string Name;
    public bool Renting;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Renting = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Renting);
    }
}