using Shared.Enums;

namespace Shared.Packets.Server.Models;

public sealed class UpdateHeroSpawnState : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UpdateHeroSpawnState; }
    }

    public HeroSpawnState State;

    public override void ReadPacket(BinaryReader reader)
    {
        State = (HeroSpawnState)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)State);
    }
}