namespace Shared.Packets.Server.Models;

public sealed class ItemRentalPartnerLock : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ItemRentalPartnerLock; }
    }

    public bool GoldLocked;
    public bool ItemLocked;

    public override void ReadPacket(BinaryReader reader)
    {
        GoldLocked = reader.ReadBoolean();
        ItemLocked = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(GoldLocked);
        writer.Write(ItemLocked);
    }
}