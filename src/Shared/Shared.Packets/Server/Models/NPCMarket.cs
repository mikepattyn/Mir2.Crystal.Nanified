using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NPCMarket : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCMarket; } }

    public List<ClientAuction> Listings = new List<ClientAuction>();
    public int Pages;
    public bool UserMode;

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Listings.Add(new ClientAuction(reader));

        Pages = reader.ReadInt32();
        UserMode = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Listings.Count);

        for (int i = 0; i < Listings.Count; i++)
            Listings[i].Save(writer);

        writer.Write(Pages);
        writer.Write(UserMode);
    }
}