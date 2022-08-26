using Shared.Models.Shared;

namespace Shared.Packets.Server.Models;

public sealed class WorldMapSetupInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.WorldMapSetup; }
    }

    public WorldMapSetup Setup;
    public int TeleportToNPCCost;

    public override void ReadPacket(BinaryReader reader)
    {
        Setup = new WorldMapSetup(reader);
        TeleportToNPCCost = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Setup.Save(writer);
        writer.Write(TeleportToNPCCost);
    }
}