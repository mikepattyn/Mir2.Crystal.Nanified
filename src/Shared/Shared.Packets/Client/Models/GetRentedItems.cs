namespace Shared.Packets.Client.Models;

public sealed class GetRentedItems : Packet
{
    public override short Index
    {
        get
        {
            return (short)ClientPacketIds.GetRentedItems;
        }
    }

    public override void ReadPacket(BinaryReader reader)
    { }

    public override void WritePacket(BinaryWriter writer)
    { }
}