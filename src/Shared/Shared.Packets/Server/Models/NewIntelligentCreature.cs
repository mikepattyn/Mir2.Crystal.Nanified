using Shared.Models.IntelligentCreature;

namespace Shared.Packets.Server.Models;

public sealed class NewIntelligentCreature : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewIntelligentCreature; }
    }

    public ClientIntelligentCreature Creature;
    public override void ReadPacket(BinaryReader reader)
    {
        Creature = new ClientIntelligentCreature(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Creature.Save(writer);
    }
}