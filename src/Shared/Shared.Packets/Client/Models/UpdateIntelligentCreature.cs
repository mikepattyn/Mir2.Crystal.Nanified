using Shared.Models.IntelligentCreature;

namespace Shared.Packets.Client.Models;

public sealed class UpdateIntelligentCreature : Packet
{
    public override short Index { get { return (short)ClientPacketIds.UpdateIntelligentCreature; } }


    public ClientIntelligentCreature Creature;
    public bool SummonMe = false;
    public bool UnSummonMe = false;
    public bool ReleaseMe = false;

    public override void ReadPacket(BinaryReader reader)
    {
        Creature = new ClientIntelligentCreature(reader);
        SummonMe = reader.ReadBoolean();
        UnSummonMe = reader.ReadBoolean();
        ReleaseMe = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Creature.Save(writer);
        writer.Write(SummonMe);
        writer.Write(UnSummonMe);
        writer.Write(ReleaseMe);
    }
}