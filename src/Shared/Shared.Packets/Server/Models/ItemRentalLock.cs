namespace Shared.Packets.Server.Models;

public sealed class ItemRentalLock : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ItemRentalLock; }
    }

    public bool Success;
    public bool GoldLocked;
    public bool ItemLocked;

    public override void ReadPacket(BinaryReader reader)
    {
        Success = reader.ReadBoolean();
        GoldLocked = reader.ReadBoolean();
        ItemLocked = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Success);
        writer.Write(GoldLocked);
        writer.Write(ItemLocked);
    }
}