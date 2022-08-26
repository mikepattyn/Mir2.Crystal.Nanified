namespace Shared.Packets.Server.Models;

public sealed class NPCRefine : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCRefine; } }

    public float Rate;
    public bool Refining;

    public override void ReadPacket(BinaryReader reader)
    {
        Rate = reader.ReadSingle();
        Refining = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Rate);
        writer.Write(Refining);
    }
}