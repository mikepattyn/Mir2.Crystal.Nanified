using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class UpdateRentalItem : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UpdateRentalItem; }
    }

    public bool HasData;
    public UserItem LoanItem;

    public override void ReadPacket(BinaryReader reader)
    {
        HasData = reader.ReadBoolean();

        if (HasData)
            LoanItem = new UserItem(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(LoanItem != null);

        if (LoanItem != null)
            LoanItem.Save(writer);
    }
}