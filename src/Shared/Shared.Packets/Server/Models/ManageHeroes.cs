using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class ManageHeroes : ServerPacket
{
    public int MaximumCount;
    public ClientHeroInformation CurrentHero;
    public ClientHeroInformation[] Heroes;
    public override short Index { get { return (short)ServerPacketIds.ManageHeroes; } }
    public override void ReadPacket(BinaryReader reader)
    {
        MaximumCount = reader.ReadInt32();

        if (reader.ReadBoolean())
            CurrentHero = new ClientHeroInformation(reader);

        if (reader.ReadBoolean())
        {
            int count = reader.ReadInt32();
            Heroes = new ClientHeroInformation[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.ReadBoolean())
                    Heroes[i] = new ClientHeroInformation(reader);
            }
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(MaximumCount);

        writer.Write(CurrentHero != null);
        if (CurrentHero != null)
            CurrentHero.Save(writer);

        writer.Write(Heroes != null);
        if (Heroes != null)
        {
            writer.Write(Heroes.Length);
            for (int i = 0; i < Heroes.Length; i++)
            {
                writer.Write(Heroes[i] != null);
                if (Heroes[i] != null)
                    Heroes[i].Save(writer);
            }
        }
    }
}