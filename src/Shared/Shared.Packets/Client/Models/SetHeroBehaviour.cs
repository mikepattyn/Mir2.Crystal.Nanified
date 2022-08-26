using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class SetHeroBehaviour : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SetHeroBehaviour; } }

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