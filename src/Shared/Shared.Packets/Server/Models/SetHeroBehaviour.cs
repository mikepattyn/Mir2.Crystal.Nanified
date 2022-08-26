using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class SetHeroBehaviour : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.SetHeroBehaviour; } }

    public HeroBehaviour Behaviour;
    public override void ReadPacket(BinaryReader reader)
    {
        Behaviour = (HeroBehaviour)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Behaviour);
    }
}