using Shared.Enums;
using Shared.Models.IntelligentCreature;

namespace Shared.Packets.Server.Models;

public sealed class UpdateIntelligentCreatureList : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UpdateIntelligentCreatureList; }
    }

    public List<ClientIntelligentCreature> CreatureList = new List<ClientIntelligentCreature>();
    public bool CreatureSummoned = false;
    public IntelligentCreatureType SummonedCreatureType = IntelligentCreatureType.None;
    public int PearlCount = 0;

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            CreatureList.Add(new ClientIntelligentCreature(reader));
        CreatureSummoned = reader.ReadBoolean();
        SummonedCreatureType = (IntelligentCreatureType)reader.ReadByte();
        PearlCount = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(CreatureList.Count);
        for (int i = 0; i < CreatureList.Count; i++)
            CreatureList[i].Save(writer);
        writer.Write(CreatureSummoned);
        writer.Write((byte)SummonedCreatureType);
        writer.Write(PearlCount);
    }
}