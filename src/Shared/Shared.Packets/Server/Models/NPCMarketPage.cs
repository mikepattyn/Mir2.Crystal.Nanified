using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NPCMarketPage : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCMarketPage; } }

    public List<ClientAuction> Listings = new List<ClientAuction>();

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Listings.Add(new ClientAuction(reader));
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Listings.Count);

        for (int i = 0; i < Listings.Count; i++)
            Listings[i].Save(writer);
    }
}