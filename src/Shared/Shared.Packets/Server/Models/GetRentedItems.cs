using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class GetRentedItems : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.GetRentedItems; }
    }

    public List<ItemRentalInformation> RentedItems = new List<ItemRentalInformation>();

    public override void ReadPacket(BinaryReader reader)
    {
        var count = reader.ReadInt32();

        for (var i = 0; i < count; i++)
            RentedItems.Add(new ItemRentalInformation(reader));
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(RentedItems.Count);

        foreach (var rentedItemInformation in RentedItems)
            rentedItemInformation.Save(writer);
    }
}